using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Item : Base
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [StringLength(50, ErrorMessage = "Maximum amount of characters is 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Item Descripton is required")]
        [StringLength(255, ErrorMessage = "Maximum amount of characters is 50")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Item Quantity is required")]
        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage ="Qty should be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Item Price is required")]
        [Range(minimum: 0.1d, maximum: Double.MaxValue, ErrorMessage = "Price should be at least 0.1$")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Justification for the item is required")]
        [StringLength(255, ErrorMessage = "Maximum amount of characters is 255")]
        public string Justification { get; set; }

        [Required(ErrorMessage = "Location for the item is required")]
        [StringLength(255, ErrorMessage = "Maximum amount of characters is 255")]
        public string Location { get; set; }

        public decimal Subtotal { get => Price * Quantity; }
        public ItemStatus Status { get; set; } = ItemStatus.Pending;
        public byte[] TimeStamp { get; set; }

        private string denyReason;
        [RequiredIf("Status", ItemStatus.Denied)]
        public string DenyReason
        {
            get
            {
                if (this.Status != ItemStatus.Denied) denyReason = "";
                return denyReason;
            }
            set
            {
                denyReason = value;
            }
        }
        
        [RequiredIf("RestrictedModifying", true)]
        public string ModifyReason { get; set; }

        [Browsable(false)]
        public bool RestrictedModifying { get; set; } = false;

        public Item() { }

        public bool NoLongerNeeded { get; set; } = false;
    }
}


public class RequiredIfAttribute : ValidationAttribute
{
    RequiredAttribute _innerAttribute = new RequiredAttribute();
    public string _dependentProperty { get; set; }
    public object _targetValue { get; set; }

    public RequiredIfAttribute(string dependentProperty, object targetValue)
    {
        this._dependentProperty = dependentProperty;
        this._targetValue = targetValue;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var field = validationContext.ObjectType.GetProperty(_dependentProperty);
        if (field != null)
        {
            var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
            if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(_targetValue)))
            {
                if (!_innerAttribute.IsValid(value))
                {
                    string name = validationContext.DisplayName;
                    return new ValidationResult(ErrorMessage = name + " Is required.");
                }
            }
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult(FormatErrorMessage(_dependentProperty));
        }
    }
}