//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace TestingDAL
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Client))]
    [KnownType(typeof(L_Country))]
    [KnownType(typeof(L_IDInformationType))]
    public partial class JointAccountInformation
    {
        [DataMember]
        public int PK_JointAccountID { get; set; }
        [DataMember]
        public string PrimaryAccountHolderTitle { get; set; }
        [DataMember]
        public string PrimaryAccountHolderFirstName { get; set; }
        [DataMember]
        public string PrimaryAccountHolderMiddleName { get; set; }
        [DataMember]
        public string PrimaryAccountHolderLastName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> PrimaryAccountHolderBirthDate { get; set; }
        [DataMember]
        public Nullable<bool> PrimaryAccountHolderGender { get; set; }
        [DataMember]
        public Nullable<int> FK_PrimaryAccountHolderCitizenshipCountryID { get; set; }
        [DataMember]
        public Nullable<int> FK_PrimaryAccountHolderIDTypeID { get; set; }
        [DataMember]
        public string PrimaryAccountHolderIDNumber { get; set; }
        [DataMember]
        public Nullable<int> FK_PrimaryAccountHolderResidenceCountryID { get; set; }
        [DataMember]
        public string SecondaryAccountHolderTitle { get; set; }
        [DataMember]
        public string SecondaryAccountHolderFirstName { get; set; }
        [DataMember]
        public string SecondaryAccountHolderMiddleName { get; set; }
        [DataMember]
        public string SecondaryAccountHolderLastName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SecondaryAccountHolderBirthDate { get; set; }
        [DataMember]
        public Nullable<bool> SecondaryAccountHolderGender { get; set; }
        [DataMember]
        public Nullable<int> FK_SecondaryAccountHolderCitizenshipCountryID { get; set; }
        [DataMember]
        public Nullable<int> FK_SecondaryAccountHolderIDTypeID { get; set; }
        [DataMember]
        public string SecondaryAccountHolderIDNumber { get; set; }
        [DataMember]
        public Nullable<int> FK_SecondaryAccountHolderResidenceCountryID { get; set; }
        [DataMember]
        public string ResidentialAddress { get; set; }
        [DataMember]
        public string ResidentialAddressCity { get; set; }
        [DataMember]
        public Nullable<int> FK_ResidentialAddressCountryID { get; set; }
        [DataMember]
        public string ResidentialAddressPostalCode { get; set; }
        [DataMember]
        public Nullable<int> MonthsAtCurrentAddress { get; set; }
        [DataMember]
        public string PreviousAddress { get; set; }
        [DataMember]
        public string PreviousAddressCity { get; set; }
        [DataMember]
        public Nullable<int> FK_PreviousAddressCounrtyID { get; set; }
        [DataMember]
        public string PreviousAddressPostalCode { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public Nullable<int> FK_ClientID { get; set; }
    
        [DataMember]
        public virtual Client Client { get; set; }
        [DataMember]
        public virtual L_Country L_Country { get; set; }
        [DataMember]
        public virtual L_IDInformationType L_IDInformationType { get; set; }
        [DataMember]
        public virtual L_Country L_Country1 { get; set; }
        [DataMember]
        public virtual L_Country L_Country2 { get; set; }
        [DataMember]
        public virtual L_Country L_Country3 { get; set; }
        [DataMember]
        public virtual L_Country L_Country4 { get; set; }
        [DataMember]
        public virtual L_Country L_Country5 { get; set; }
        [DataMember]
        public virtual L_IDInformationType L_IDInformationType1 { get; set; }
    }
    
}
