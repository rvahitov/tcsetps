using System;
using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Correct.Storage.Domain.Models.BoxModel
{
    /// <summary>
    ///     идентификатор короба
    /// </summary>
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class BoxId : Identity<BoxId>
    {
        private static readonly Guid BarcodeNamespace = new Guid("413C538D-59F6-4CC4-951F-330B13E1F448");
        public BoxId(string value) : base(value)
        {
        }

        public static BoxId ForBarcode(string barcode)
        {
            return NewDeterministic(BarcodeNamespace, barcode);
        }
    }
}