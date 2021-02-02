using Model.DTO;
using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReviewService
    {
        private ReviewDB reviewDB;

        public bool AddReview(Review r)
        {
            reviewDB = new ReviewDB();
            return reviewDB.AddReview(r);
        }

        public List<Error> ReviewValidation(Review r)
        {
            if (r.Comment == "")
            {
                r.AddError(new Error("Comment field cannot be empty"));
            }
            if(r.EmployeeId < 1)
            {
                r.AddError(new Error("Please select employee "));
            }
            if(r.ReviewDate > DateTime.Now)
            {
                r.AddError(new Error("Review Date cannot be in future"));
            }

            return r.Errors;
        }

        public List<Review> GetEmpReviews(int empId)
        {
            reviewDB = new ReviewDB();
            return reviewDB.GetEmpReviews(empId);
        }

        public ReviewDetailsDTO GetreviewDetails(int id)
        {
            reviewDB = new ReviewDB();
            return reviewDB.GetreviewDetails(id);
        }

        public bool UpdateLastEmailSendDate()
        {
            reviewDB = new ReviewDB();
            return reviewDB.UpdateLastEmailSendDate();
        }

        public DateTime LastEmailSentDate() {
            reviewDB = new ReviewDB();
            return reviewDB.LastEmailSentDate();
        }
    }
}
