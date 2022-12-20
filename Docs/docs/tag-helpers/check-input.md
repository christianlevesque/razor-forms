# \<check-input>

The `<check-input>` tag helper is used to create check-based `<input>` elements.

The `<check-input>` tag helper **does not generate error messages** if its corresponding model member fails validation because it's unlikely you need validation messages on a specific checkbox. In order to render error messages for a model member represented by checkboxes, wrap the `<check-input>` tag helper instances in a `<check-input-group>` tag helper.

The `<check-input>` tag helper **renders child content** as a raw HTML child of the generated `<label>`.

## Usage notes

### Basic usage

To use the `<check-input>` tag helper, all you need to do is add it to the form and supply the `asp-for` attribute, just like you would with the built-in `<input>` tag helper:

```csharp
public class MyModel : PageModel
{
    [BindProperty]
    public bool AcceptTos { get; set; }
}
```

```cshtml
@model MyModel

<form>
    <check-input asp-for="AcceptTos">
        I agree to the <a asp-page="/terms">Terms of Service</a>
    </check-input>
</form>
```

### Binding to a list

The `<check-input>` tag helper can also bind to multiple non-boolean values. To do so, you need a model member of type `List<T>` to bind with:

```csharp
public class MyModel : PageModel
{
    [BindProperty]
    public List<int> LuckyNumbers { get; set; }
}
```

```cshtml
@model MyModel

<form>
    <check-input asp-for="LuckyNumbers" value="3">
        3
    </check-input>
    <check-input asp-for="LuckyNumbers" value="7">
        7
    </check-input>
    <check-input asp-for="LuckyNumbers" value="13">
        13
    </check-input>
</form>
```

## Generated HTML

The HTML generated by the `<check-input>` tag helper looks like this:

```html
<div> <!-- component wrapper -->
    <div> <!-- label wrapper, disable in configuration -->
        <!-- input "id" and label "for" are GUIDs -->
        <label for="f16a9089-ca84-485b-bb16-b256c3591469">
            I accept the Terms of Service
        </label>
    </div>
    <div> <!-- input wrapper, disable in configuration -->
        <input id="f16a9089-ca84-485b-bb16-b256c3591469"
               value="true"
               type="checkbox" 
               name="AcceptTos">
    </div>
</div>
```