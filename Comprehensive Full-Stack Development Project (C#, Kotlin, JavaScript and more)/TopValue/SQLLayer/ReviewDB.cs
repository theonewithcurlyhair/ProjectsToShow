using DAL;
using Model;
using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Types.Types;

namespace SQLLayer
{
    public class ReviewDB
    {
        public bool AddReview(Review r)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@perfomanceRating", r.PerfomanceRating, SqlDbType.VarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@comment", r.Comment, SqlDbType.VarChar, ParameterDirection.Input, 250));
            parms.Add(new ParmStruct("@reviewDate", r.ReviewDate, SqlDbType.DateTime, ParameterDirection.Input));
            parms.Add(new ParmStruct("@employeeId", r.EmployeeId, SqlDbType.Int, ParameterDirection.Input));


            int insertSuccess = db.ExecuteNonQuery("sp_CreateReview", CommandType.StoredProcedure, parms);
            return insertSuccess > 0;
        }

        public List<Review> GetEmpReviews(int empId)
        {
            List<Review> reviews = new List<Review>();
            Review review;
            try
            {
                DataAccess db = new DataAccess();
                List<ParmStruct> parms = new List<ParmStruct>();

                parms.Add(new ParmStruct("@empId", empId, SqlDbType.Int, ParameterDirection.Input, 50));


                DataTable dt = db.Execute("sp_GetEmpReviews", CommandType.StoredProcedure, parms);
                foreach (DataRow row in dt.Rows)
                {
                    review = new Review();
                    review.ID = Convert.ToInt32(row["ID"]);
                    review.ReviewDate = Convert.ToDateTime(row["ReviewDate"]);
                    if (review.ReviewDate.Month >= 4 && review.ReviewDate.Month <= 6)
                        review.ReviewQuater =  1;
                    else if (review.ReviewDate.Month >= 7 && review.ReviewDate.Month <= 9)
                        review.ReviewQuater = 2;
                    else if (review.ReviewDate.Month >= 10 && review.ReviewDate.Month <= 12)
                        review.ReviewQuater = 3;
                    else
                        review.ReviewQuater = 4;
                    reviews.Add(review);
                }
            }
            catch (Exception ex)
            {
                review = new Review();
                review.AddError(new Error(ex.Message));
                reviews.Add(review);
            }
            return reviews;
        }

        public ReviewDetailsDTO GetreviewDetails(int id)
        {
            ReviewDetailsDTO dto = new ReviewDetailsDTO();
            Review review = new Review();
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@id", id, SqlDbType.Int, ParameterDirection.Input, 50));


            DataTable dt = db.Execute("sp_GetReviewDetails", CommandType.StoredProcedure, parms);
            foreach (DataRow row in dt.Rows)
            {
                review = new Review();
                review.ReviewDate = Convert.ToDateTime(row["ReviewDate"]);
                review.Comment = row["Comment"].ToString();
                Enum.TryParse(row["PerfomanceRating"].ToString(), out PerfomanceRating perfomanceRating);
                review.PerfomanceRating = perfomanceRating;
                dto.review = review;
                dto.SupervisorName = row["Name"].ToString();
            }

            return dto;
        }

        public bool UpdateLastEmailSendDate()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();

            int update = db.ExecuteNonQuery("sp_UpdateEmailSendDate", CommandType.StoredProcedure, parms);
            return update > 0;
        }

        public DateTime LastEmailSentDate()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();
            object scaler = db.ExecuteScaler("SELECT LastReminderSent FROM EmailReminder", CommandType.Text, parms);
            DateTime update = DateTime.Now;
            if (scaler != null)
            {
                update = (DateTime)scaler;
            }
            return update;
        }
    }
}
