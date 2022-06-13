﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorForms.Generators;
using RazorForms.Options;

namespace RazorForms.TagHelpers;

public class TextAreaInputTagHelper : RazorFormsTagHelperBase
{
	/// <inheritdoc />
	public TextAreaInputTagHelper(IHtmlGenerator generator,
                                  ITextAreaOptions options,
                                  IInputBlockWrapperGenerator inputBlockWrapperGenerator,
                                  ILabelGenerator labelGenerator,
                                  ITextAreaGenerator inputGenerator,
                                  IErrorGenerator errorGenerator) : base(generator,
                                                                         options,
                                                                         inputBlockWrapperGenerator,
                                                                         labelGenerator,
                                                                         inputGenerator,
                                                                         errorGenerator)
	{
	}
}