# \<text-input>

The `<text-input>` tag helper is used to create `<input>` elements. The tag helper detects what the `type` attribute of the `<input>` should be in most cases, so you don't usually need to supply a `type`.

The `<text-input>` tag helper **generates error messages** if its corresponding model member fails validation.

The `<text-input>` tag helper **renders child content** as a raw HTML child of the generated `<label>`.

## Usage notes

### Basic usage

To use the `<text-input>` tag helper, all you need to do is add it to the form and supply the `asp-for` attribute, just like you would with the built-in `<input>` tag helper:

```csharp
public class MyModel : PageModel
{
    [BindProperty]
    public string FirstName { get; set; }

    [BindProperty]
    public int Age { get; set; }
}
```

```cshtml
@model MyModel

<form>
    <text-input asp-for="FirstName" />
    <text-input asp-for="Age" />
</form>
```

## Generated HTML

The HTML generated by the `<text-input>` tag helper looks like this:

```html
<div> <!-- component wrapper -->
    <div> <!-- input block wrapper -->
        <div> <!-- label wrapper, disable in configuration -->
            <label for="FirstName">
                First name
            </label>
        </div>

        <div> <!-- input wrapper, disable in configuration -->
            <!-- type varies based on model -->
            <input type="text"
                   id="FirstName"
                   name="FirstName"
                   value="">
        </div>
    </div>

    <ul> <!-- error wrapper, only rendered if errors are present -->
        <li>...</li>
    </ul>
</div>
```