
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
    
public partial class Contract : Job
{

    public Contract()
    {

        this.Draws = new HashSet<Draw>();

    }


    public decimal ContractPrice { get; set; }



    public virtual ICollection<Draw> Draws { get; set; }

}

}
