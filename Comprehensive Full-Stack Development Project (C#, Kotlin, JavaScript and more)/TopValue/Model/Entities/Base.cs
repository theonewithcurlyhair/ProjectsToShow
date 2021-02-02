using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public abstract class Base : IDataErrorInfo
    {
        private List<Error> errors = new List<Error>();
        [Browsable(false)]
        public List<Error> Errors
        {
            get
            {
                List<ValidationResult> results = new List<ValidationResult>();
                var result = Validator.TryValidateObject(this,
                    new ValidationContext(this, null, null), results, true);

                if (!result)
                {
                    List<Error> errs = new List<Error>();
                    results.ForEach(r => errs.Add(new Error(errs.Count+1,r.ErrorMessage, "ValidationResult")));
                    return errs;
                }else if (errors.Count > 0)
                {
                    return errors;
                }
                return new List<Error>();
            }
            set { errors = value; }
        }

        public void AddError(Error e)
        {
            errors.Add(e);
        }

        [Browsable(false)]
        public string this[string property]
        {
            get
            {
                var propertyDescriptor = TypeDescriptor.GetProperties(this)[property];
                if (propertyDescriptor == null)
                    return string.Empty;

                var results = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(
                                          propertyDescriptor.GetValue(this),
                                          new ValidationContext(this, null, null)
                                          { MemberName = property },
                                          results);
                if (!result)
                    return results.First().ErrorMessage;
                return string.Empty;
            }
        }

        [Browsable(false)]
        public string Error
        {
            get
            {
                var results = new List<ValidationResult>();
                var result = Validator.TryValidateObject(this,
                    new ValidationContext(this, null, null), results, true);
                if (!result)
                    return string.Join("\n", results.Select(x => x.ErrorMessage));
                else
                    return null;
            }
            set { }

        }
    }
}
