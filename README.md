# BlazorGravatar https://github.com/PSCourtney/BlazorGravatar

The **BlazorGravatar** library is a Blazor component that generates Gravatar profile images based on email addresses. It supports customizable image sizes, classes, alt text, and fallback options for default images and ratings.

## 📒 Features

- Automatically generates a Gravatar image URL based on the provided email address.
- Supports optional parameters for customizing image size, default fallback image, and rating level.
- Easy-to-use Razor syntax for integration into your Blazor project.

## 🛠 Installation

1. Install the NuGet package (replace `<version>` with the latest version):

   ```bash
   dotnet add package BlazorGravatar --version <version>
   ```

2. Add the namespace to your `_Imports.razor` file for convenience:

   ```razor
   @using BlazorGravatar
   ```

## 🚀 Usage

### 🔹 Basic Example

Render a Gravatar image for an email address:

```razor
<BlazorGravatar Email="user@example.com" Alt="User's Gravatar" />
```

### 🔸 Custom Size, Class, and Default Image

```razor
<BlazorGravatar
    Email="user@example.com"
    Alt="User's Profile Image"
    Size="100"
    Class="profile-picture"
    DefaultImage="retro"
/>
```

## ⚙️ Parameters

| Parameter      | Type     | Description                                                                                 | Default |
| -------------- | -------- | ------------------------------------------------------------------------------------------- | ------- |
| `Email`        | `string` | **Required**. The email address used to fetch the Gravatar image.                           | N/A     |
| `Class`        | `string` | CSS class to style the `<img>` element.                                                     | `null`  |
| `Alt`          | `string` | Alternative text for the `<img>` element.                                                   | `null`  |
| `Size`         | `int?`   | Image size in pixels. Must be between `1` and `2048`.                                       | `null`  |
| `DefaultImage` | `string` | Default image if no Gravatar is found. Options: `404`, `mp`, `identicon`, `monsterid`, etc. | `"mp"`  |
| `Rating`       | `string` | Maximum rating of images allowed: `g`, `pg`, `r`, or `x`.                                   | `"g"`   |

## 🖼️ Supported Default Images

- `404`: Do not load any image; return an HTTP 404 instead.
- `mp`: Mystery Person silhouette (default).
- `identicon`: Geometric pattern based on email hash.
- `monsterid`: Monster face generated based on email hash.
- `retro`: 8-bit arcade-style image.
- And more... see [Gravatar's official documentation](https://en.gravatar.com/site/implement/images/).

## 🎨 Example with Styling

Add custom styles for the Gravatar image:

```razor
<BlazorGravatar
    Email="user@example.com"
    Alt="Avatar"
    Class="rounded-circle shadow-sm"
    Size="150"
/>
```

```css
/* Custom CSS */
.rounded-circle {
    border-radius: 50%;
}

.shadow-sm {
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}
```

## ⚙️ How It Works

The **BlazorGravatar** component normalizes the email address (lowercase and trimmed), computes an SHA256 hash, and generates the Gravatar URL. Optional parameters like size, default image, and rating are added as query parameters.

## 🤝 Contributing

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit and push your changes.
4. Submit a pull request with a detailed explanation of your changes.

## 📄 License

This project is licensed under the [MIT License](LICENSE).

## 🙏 Acknowledgments

The Gravatar API is provided by [Gravatar.com](https://gravatar.com).

