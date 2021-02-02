using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum OrderStatus
    {
        Pending = 1,
        UnderReview = 2,
        Closed = 3
    }


    public enum ItemStatus
    {
        Pending = 1,
        Approved = 2,
        Denied = 3
    }

    public enum Status
    {
        Active = 1,
        Retired = 2,
        Terminated = 3
    }

    public enum PerfomanceRating
    {
        [Display(Name = "Below Expectations")]
        BelowExpectations,
        [Display(Name = "Meet Expetations")]
        MeetExpetations,
        [Display(Name = "Exceeds Expectations")]
        ExceedsExpectations
    }

    public enum Country
    {
        Canada = 1,
        USA = 2
    }

    public enum Provincies
    {
        Alberta,
        [Display(Name = "British Columbia")]
        BritishColumbia, 
        Manitoba,
        [Display(Name = "New Brunswick")]
        NewBrunswick,
        [Description("Newfoundlan And Labrador")]
        NewfoundlandAndLabrador,
        [Display(Name = "Nova Scotia")]
        NovaScotia, 
        Ontario,
        [Display(Name = "Prince Edward Island")]
        PrinceEdwardIsland, 
        Quebec,
        Saskatchewan
    }

    public enum States
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        [Display(Name = "New Hampshire")]
        NewHampshire,
        [Display(Name = "New Jersey")]
        NewJersey,
        [Display(Name = "New Mexico")]
        NewMexico,
        [Display(Name = "New York")]
        NewYork,
        [Display(Name = "North Carolina")]
        NorthCarolina,
        [Display(Name = "North Dakota")]
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        [Display(Name = "Rhode Island")]
        RhodeIsland,
        [Display(Name = "South Carolina")]
        SouthCarolina,
        [Display(Name = "South Dakota")]
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        [Display(Name = "West Virginia")]
        WestVirginia,
        Wisconsin,
        Wyoming,
    }
}
