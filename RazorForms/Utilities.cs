﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using RazorForms.Options;

namespace RazorForms;

public static class Utilities
{
	/// <summary>
	/// Gets the <see cref="DescriptionAttribute"/> value associated with an enum member. If it does not exist, it returns the enum member stringified.
	/// </summary>
	/// <param name="e"></param>
	/// <returns></returns>
	public static string GetDescription(this Enum e)
	{
		var attr = e.GetType()
		            .GetField(e.ToString())?
		            .GetCustomAttributes(typeof (DescriptionAttribute), false)
		            .FirstOrDefault() as DescriptionAttribute;
		return attr?.Description ?? e.ToString();
	}

	/// <summary>
	/// Appends a value to the given <see cref="StringBuilder"/> instance, including a leading space if the instance is not currently empty
	/// </summary>
	/// <param name="self">the <see cref="StringBuilder"/> instance</param>
	/// <param name="input">the value to append</param>
	public static void AppendWithLeadingSpace(this StringBuilder self, string? input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return;
		}

		var value = self.Length == 0 ? input : $" {input}";
		self.Append(value);
	}

	/// <summary>
	/// Generates the &lt;label&gt; inner text and surrounds it with an HTML tag if necessary
	/// </summary>
	/// <param name="options">the current tag helper's <see cref="IFormComponentOptions"/></param>
	/// <param name="text">the inner text to display in the &lt;label&gt;</param>
	/// <returns></returns>
	public static string GenerateLabelText(IFormComponentOptions options, string text)
	{
		return string.IsNullOrWhiteSpace(options.LabelTextHtmlWrapper)
			? text
			: $"<{options.LabelTextHtmlWrapper}>{text}</{options.LabelTextHtmlWrapper}>";
	}
}