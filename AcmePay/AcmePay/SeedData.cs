using AcmePay.Data.Entity;
using AcmePay.Models.Enums;

namespace AcmePay;

public static class SeedData
{
    public static void Initialize(AcmeContext context)
    {
        context.PaymentMethods.AddRange(
            new PaymentMethod
            {
                Name = "VISA",
                Fields = new List<Field>
                {
                    new Field
                    {
                        Name = "CardNumber",
                        Label = "Card Number",
                        Type = (int)FieldTypes.Text,
                        Validator = new Validator
                        {
                            Required = true,
                        }
                    },
                    new Field
                    {
                        Name = "ExpirationDate",
                        Label = "Expiration Date",
                        Type = (int)FieldTypes.Text,
                        PlaceHolder = "mm/yy",
                        Validator = new Validator
                        {
                            Required = true,
                            Pattern = @"^(0[1-9]|1[0-2])\/?([0-9]{2})$",
                        }
                    },
                    new Field
                    {
                        Name = "CVC",
                        Label = "CVC",
                        Type = (int)FieldTypes.Number,
                        Validator = new Validator
                        {
                            Required = true,
                            MaxLength = 3,
                            MinLength = 3
                        }
                    },
                    new Field
                    {
                        Name = "CardHolder",
                        Label = "Card Holder",
                        Type = (int)FieldTypes.Text,
                        Validator = new Validator
                        {
                            Required = true,
                            MaxLength = 50,
                            MinLength = 15,
                        }
                    }
                }
            },
            new PaymentMethod
            {
                Name = "SEPA",
                Fields = new List<Field>
                {
                    new Field
                    {
                        Name = "IBAN",
                        Label = "IBAN",
                        Type = (int)FieldTypes.Text,
                        Validator = new Validator
                        {
                            Required = true,
                            MinLength = 15,
                            MaxLength = 32
                        }
                    },
                    new Field
                    {
                        Name = "BIC",
                        Label = "BIC",
                        Type = (int)FieldTypes.Text,
                        Validator = new Validator
                        {
                            Required = true,
                            MinLength = 8,
                        }
                    },
                    new Field
                    {
                        Name = "HolderName",
                        Label = "Holder Name",
                        Type = (int)FieldTypes.Text,
                        Validator = new Validator
                        {
                            Required = true,
                            MaxLength = 50,
                            MinLength = 15,
                        }
                    }
                }
            }
        );
        context.SaveChanges();
    }
}