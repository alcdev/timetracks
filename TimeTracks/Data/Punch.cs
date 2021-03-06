
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace TimeTracks.Data
{

using System;
    using System.Collections.Generic;
    
public partial class Punch
{

    public Punch()
    {

        this.Notes = new HashSet<Note>();

    }


    public int Id { get; set; }

    public System.DateTime Date { get; set; }

    public System.DateTime PunchIn { get; set; }

    public Nullable<System.DateTime> PunchOut { get; set; }

    public int PunchedInBy { get; set; }

    public Nullable<int> PunchedOutBy { get; set; }

    public Nullable<bool> Verified { get; set; }

    public Nullable<int> VerifiedBy { get; set; }



    public virtual ICollection<Note> Notes { get; set; }

    public virtual Job Job { get; set; }

    public virtual Company Company { get; set; }

}

}
