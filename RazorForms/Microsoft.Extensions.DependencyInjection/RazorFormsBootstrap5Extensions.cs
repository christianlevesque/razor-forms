using System;
using RazorForms;
using RazorForms.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class RazorFormsBootstrap5Extensions
{
	private const string TemplateBasePath = "RazorFormsTemplates";
	private const string ValidityAwareContentPartial = $"{TemplateBasePath}/Partials/ValidityAwareContent";
	private const string ContentPartial = $"{TemplateBasePath}/Partials/Content";

	/// <summary>
	/// Adds RazorForms support, configured to use basic Bootstrap 5 settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include basic Bootstrap 5 support. This will probably serve as a starting place for your own app, but you'll probably want to add customized options in all but the most basic of scenarios.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5(this IServiceCollection self) => self.UseRazorForms(_bootstrapDefaults);

	/// <summary>
	/// Adds RazorForms support with configurable Bootstrap 5 settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable Bootstrap 5 support.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default Bootstrapv5 options</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5(this IServiceCollection self, Action<RazorFormsOptions> action)
	{
		action(_bootstrapDefaults);
		return self.UseRazorForms(_bootstrapDefaults);
	}

	/// <summary>
	/// Add RazorForms support with configurable Bootstrap 5 settings, along with added configuration to set up Bootstrap floating form labels
	/// </summary>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default Bootstrapv5 options</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5FloatingLabels(this IServiceCollection self,
		Action<RazorFormsOptions> action)
	{
		// Inputs
		_bootstrapDefaults.InputOptions.InputBlockWrapperClasses = "form-floating";
		_bootstrapDefaults.InputOptions.InputFirst = true;
		_bootstrapDefaults.InputOptions.RemoveWrappers = true;

		// TextAreas
		_bootstrapDefaults.TextAreaOptions.InputBlockWrapperClasses = "form-floating";
		_bootstrapDefaults.TextAreaOptions.InputFirst = true;
		_bootstrapDefaults.TextAreaOptions.RemoveWrappers = true;

		// Selects
		_bootstrapDefaults.SelectOptions.InputBlockWrapperClasses = "form-floating";
		_bootstrapDefaults.SelectOptions.InputFirst = true;
		_bootstrapDefaults.SelectOptions.RemoveWrappers = true;

		return self.UseRazorFormsWithBootstrap5(action);
	}

	private static RazorFormsOptions _bootstrapDefaults = new()
	{
		InputOptions = new FormComponentWithValidationOptions
		{
			TemplatePath = ValidityAwareContentPartial,
			LabelClasses = "form-label",
			LabelErrorClasses = "text-danger",
			LabelValidClasses = "text-success",
			InputClasses = "form-control",
			InputValidClasses = "is-valid",
			InputErrorClasses = "is-invalid",
			ErrorWrapperClasses = "text-danger list-unstyled"
		},
		CheckInputOptions = new FormComponentOptions
		{
			TemplatePath = ContentPartial,
			InputBlockWrapperClasses = "form-check",
			LabelClasses = "form-check-label",
			InputClasses = "form-check-input",
			InputFirst = true,
			RemoveWrappers = true
		},
		CheckInputGroupOptions = new FormComponentWithValidationOptions
		{
			TemplatePath = ValidityAwareContentPartial,
			LabelClasses = "form-label",
			LabelErrorClasses = "text-danger",
			LabelValidClasses = "text-success",
			ErrorWrapperClasses = "text-danger list-unstyled"
		},
		RadioInputOptions = new FormComponentOptions
		{
			TemplatePath = ContentPartial,
			InputBlockWrapperClasses = "form-check",
			LabelClasses = "form-check-label",
			InputClasses = "form-check-input",
			InputFirst = true,
			RemoveWrappers = true
		},
		RadioInputGroupOptions = new FormComponentWithValidationOptions
		{
			TemplatePath = ValidityAwareContentPartial,
			LabelClasses = "form-label",
			LabelErrorClasses = "text-danger",
			LabelValidClasses = "text-success",
			ErrorWrapperClasses = "text-danger list-unstyled"
		},
		TextAreaOptions = new FormComponentWithValidationOptions
		{
			TemplatePath = ValidityAwareContentPartial,
			LabelClasses = "form-label",
			LabelErrorClasses = "text-danger",
			LabelValidClasses = "text-success",
			InputClasses = "form-control",
			InputValidClasses = "is-valid",
			InputErrorClasses = "is-invalid",
			ErrorWrapperClasses = "text-danger list-unstyled"
		},
		SelectOptions = new FormComponentWithValidationOptions
		{
			TemplatePath = ValidityAwareContentPartial,
			LabelClasses = "form-label",
			LabelErrorClasses = "text-danger",
			LabelValidClasses = "text-success",
			InputClasses = "form-select",
			InputValidClasses = "is-valid",
			InputErrorClasses = "is-invalid",
			ErrorWrapperClasses = "text-danger list-unstyled"
		}
	};
}