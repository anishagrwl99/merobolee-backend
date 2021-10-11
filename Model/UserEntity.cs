using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_user")]
    public class UserEntity : BaseEntity
    {
        private long user_Id;
        private Guid user_Code;
        private int? country_Id;
        private int? province_Id;
        private int? district_Id;
        private int? city_Id;
        private int? role_Id;
        private int register_Country;
        private string registration_No;
        private string company_Name;
        private int? company_Type_Id;
        private string company_acronym;
        private string description;
        private int employee_no;
        private int? category_Id;
        private string vat_Pan_No;
        private string website;
        private string address1;
        private string address2;
        private string address3;
        private int? municipality_Id;
        private int? vdc_id;
        private string fax_No;
        private string company_email;
        private string company_Contact1;
        private string company_Contact2;
        private string salutation;
        private string first_Name;
        private string middle_Name;
        private string last_Name;
        private string designation;
        private string person_contact1;
        private string person_contact2;
        private string person_email;
        private string username;
        private string password;
        private DateTime? activate_Date;
        private DateTime? expried_Date;
        private string front_Citizenship;
        private string back_Citizenship;
        private string tax_Clearance;
        private string pan_Vat_Registration;
        private string company_Registration;
        private int? status_id;
        private ICollection<UserExperienceDocEntity> experienced_document;
        private string bank_credit_letter;
        private int? membership_Id;
        private CountryEntity country;
        private ProvinceEntity province;
        private DistrictEntity district;
        private CityEntity city;
        private UserStatusEntity userStatus;
        private  MembershipTypeEntity membershipType;
        private CategoryEntity category;
        private RoleEntity role;
        private MunicipalityEntity municipality;
        private VDCEntity vdc;
        private CompanyTypeEntity companyType;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public long User_Id { get => user_Id; set => user_Id = value; }

        [Column("user_code")]        
        public Guid User_Code { get => user_Code; set => user_Code = value; }

        [Column("country_id")]
        [ForeignKey("Country")]
        public int? Country_Id { get => country_Id; set => country_Id = value; }

        [Column("province_id")]
        [ForeignKey("Province")]
        public int? Province_Id { get => province_Id; set => province_Id = value; }

        [Column("district_id")]
        [ForeignKey("District")]
        public int? District_Id { get => district_Id; set => district_Id = value; }

        [Column("city_id")]
        [ForeignKey("City")]
        public int? City_Id { get => city_Id; set => city_Id = value; }

        [Column("role_id")]
        [ForeignKey("Role")]
        public int? Role_Id { get => role_Id; set => role_Id = value; }

        [Column("register_country_id")]
      //  [ForeignKey("Country")]
        public int Register_Country { get => register_Country; set => register_Country = value; }

        [Column("registration_no")]
        public string Registration_No { get => registration_No; set => registration_No = value; }

        [Column("company_name")]
        public string Company_Name { get => company_Name; set => company_Name = value; }

        [Column("company_type_Id")]
        [ForeignKey("CompanyType")]
        public int? Company_Type_Id { get => company_Type_Id; set => company_Type_Id = value; }

        [Column("acronym")]
        public string Company_acronym { get => company_acronym; set => company_acronym = value; }

        [Column("description")]
        public string Description { get => description; set => description = value; }

        [Column("no_of_employee")]
        public int Employee_no { get => employee_no; set => employee_no = value; }

        [Column("category_id")]
        [ForeignKey("Category")]
        public int? Category_Id { get => category_Id; set => category_Id = value; }

        [Column("vat_pan_no")]
        public string Vat_Pan_No { get => vat_Pan_No; set => vat_Pan_No = value; }
        
        [Column("website")]
        public string Website { get => website; set => website = value; }

        [Column("address1")]
        public string Address1 { get => address1; set => address1 = value; }

        [Column("address2")]
        public string Address2 { get => address2; set => address2 = value; }

        [Column("address3")]
        public string Address3 { get => address3; set => address3 = value; }

        [Column("municipality_id")]

        public int? Municipality_Id { get => municipality_Id; set => municipality_Id = value; }

        [Column("vdc_id")]
        public int? Vdc_id { get => vdc_id; set => vdc_id = value; }

        [Column("fax_no")]
        public string Fax_No { get => fax_No; set => fax_No = value; }

        [Column("comapny_email")]
        public string Company_email { get => company_email; set => company_email = value; }

        [Column("company_contact1")]
        public string Company_Contact1 { get => company_Contact1; set => company_Contact1 = value; }

        [Column("company_contact2")]
        
        public string Company_Contact2 { get => company_Contact2; set => company_Contact2 = value; }

        [Column("salutation")]
        public string Salutation { get => salutation; set => salutation = value; }

        [Column("first_name")]
        public string First_Name { get => first_Name; set => first_Name = value; }

        [Column("middle_name")]
        
        public string Middle_Name { get => middle_Name; set => middle_Name = value; }

        [Column("last_name")]
        public string Last_Name { get => last_Name; set => last_Name = value; }

        [Column("designation")]
        public string Designation { get => designation; set => designation = value; }

        [Column("person_contact1")]
        public string Person_contact1 { get => person_contact1; set => person_contact1 = value; }

        [Column("person_contact2")]
        public string Person_contact2 { get => person_contact2; set => person_contact2 = value; }

        [Column("person_email")]
        public string Person_email { get => person_email; set => person_email = value; }

        [Column("username")]
        public string Username { get => username; set => username = value; }

        [Column("password")]
        public string Password { get => password; set => password = value; }

        [Column("activate_date")]
        public DateTime? Activate_Date { get => activate_Date; set => activate_Date = value; }

        [Column("expired_date")]
        public DateTime? Expried_Date { get => expried_Date; set => expried_Date = value; }

        
        public virtual CountryEntity Country { get => country; set => country = value; }
        public virtual ProvinceEntity Province { get => province; set => province = value; }
        public virtual DistrictEntity District { get => district; set => district = value; }
        public virtual CityEntity City { get => city; set => city = value; }
        public virtual UserStatusEntity  UserStatus { get => userStatus; set => userStatus = value; }
        public virtual MembershipTypeEntity MembershipType { get => membershipType; set => membershipType = value; }
        public virtual RoleEntity Role { get => role; set => role = value; }

        [ForeignKey("Municipality_Id")]
        public virtual MunicipalityEntity Municipality { get => municipality; set => municipality = value; }

        [ForeignKey("Vdc_id")]
        public virtual VDCEntity VDC { get => vdc; set => vdc = value; }
        public virtual CompanyTypeEntity CompanyType { get => companyType; set => companyType = value; }

        [Column("front_citizenship")]
        public string Front_Citizenship { get => front_Citizenship; set => front_Citizenship = value; }

        [Column("back_citizenship")]
        public string Back_Citizenship { get => back_Citizenship; set => back_Citizenship = value; }

        [Column("tax_clearance")]
        public string Tax_Clearance { get => tax_Clearance; set => tax_Clearance = value; }

        [Column("pan_vat_registration")]
        public string Pan_Vat_Registration { get => pan_Vat_Registration; set => pan_Vat_Registration = value; }

        [Column("company_registration")]
        public string Company_Registration { get => company_Registration; set => company_Registration = value; }

        public ICollection<UserExperienceDocEntity> Experienced_document { get => experienced_document; set => experienced_document = value; }

        [Column("bank_credit_letter")]
        public string Bank_credit_letter { get => bank_credit_letter; set => bank_credit_letter = value; }
       
        [Column("membership_Id")]
        [ForeignKey("MembershipType")]
        public int? Membership_Id { get => membership_Id; set => membership_Id = value; }
        public virtual CategoryEntity Category { get => category; set => category = value; }
      //  public string User_experience { get => user_experience; set => user_experience = value; }
      //  public CompanyTypeEntity CompanyType { get => companyType; set => companyType = value; }

        [Column("status_id")]
        [ForeignKey("UserStatus")]
        public int? Status_id { get => status_id; set => status_id = value; }

    }
}
