using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGravatar
{
    public partial class BlazorGravatar : ComponentBase
    {
        [Parameter]
        public string Email { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Alt { get; set; }

        [Parameter]
        public int? Size { get; set; } // Optional: size for the Gravatar image

        [Parameter]
        public string? DefaultImage { get; set; } = "mp"; // Optional: default image to use if no Gravatar

        [Parameter]
        public string? Rating { get; set; } = "g"; // Optional: rating level for the Gravatar image

        public string GetGravatarUrl(string email)
        {
            // Normalize the email address: trim and convert to lowercase
            email = email.Trim().ToLower();

            // Compute SHA256 hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] emailBytes = Encoding.UTF8.GetBytes(email);
                byte[] hashBytes = sha256.ComputeHash(emailBytes);

                // Convert the hash bytes to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                // Build the Gravatar URL with additional parameters
                string hashString = sb.ToString();
                string gravatarUrl = $"https://www.gravatar.com/avatar/{hashString}";

                // Add optional query parameters (size, default image, rating)
                var queryParameters = new List<string>();
                if (Size.HasValue)
                {
                    queryParameters.Add($"s={Size.Value}");
                }
                if (!string.IsNullOrEmpty(DefaultImage))
                {
                    queryParameters.Add($"d={DefaultImage}");
                }
                if (!string.IsNullOrEmpty(Rating))
                {
                    queryParameters.Add($"r={Rating}");
                }

                if (queryParameters.Count > 0)
                {
                    gravatarUrl += "?" + string.Join("&", queryParameters);
                }

                return gravatarUrl;
            }
        }
    }
}
