using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AspNetCoreUploadTest.Models.Validation;

// https://stackoverflow.com/questions/4730183/mvc-model-require-true/9036075
public class EnforceTrueAttribute : ValidationAttribute, IClientModelValidator
{
    public override bool IsValid(object value)
    {
        if (value == null) return false;
        if (value.GetType() != typeof(bool)) throw new InvalidOperationException("can only be used on boolean properties.");

        return (bool)value;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        MergeAttribute(context.Attributes, "data-val", "true");
        var errorMessage = ErrorMessage ?? $"The value for field {context.ModelMetadata.GetDisplayName()} must be true.";
        MergeAttribute(context.Attributes, "data-val-enforcetrue", errorMessage);
    }

    private void MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    {
        if (attributes.ContainsKey(key))
        {
            return;
        }
        attributes.Add(key, value);
    }
}