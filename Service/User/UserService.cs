using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.User
{
    public class UserService : UserMapper, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ICryptoService cryptoService;
        private UploadImage uploadImage = new UploadImage();
        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
        }
        public async Task<GetUserDto> AddUser(AddUserDto userDto/*, IFormFile frontCitizenship, IFormFile backCitizenship, IFormFile taxClearance, IFormFile PANRegistration, IFormFile companyRegistration, IFormFile experienceDoc, IFormFile bankCreditLetter*/)
        {
            UserEntity user = UserDtoEntity(userDto);
            user.Password = cryptoService.Encrypt(user.Password);
            try
            {


                if (userDto.Front_Citizenship == null)
                {
                    user.Front_Citizenship = null;
                }
                else
                {
                    user.Front_Citizenship = await uploadImage.Upload(userDto.Front_Citizenship, userDto.Company_Name);
                }
                if (userDto.Back_Citizenship == null)
                {
                    user.Back_Citizenship = null;
                }
                else
                {
                    user.Back_Citizenship = await uploadImage.Upload(userDto.Back_Citizenship, userDto.Company_Name);
                }
                if (userDto.Tax_Clearance == null)
                {
                    user.Tax_Clearance = null;
                }
                else
                {
                    user.Tax_Clearance = await uploadImage.Upload(userDto.Tax_Clearance, userDto.Company_Name);
                }
                if (userDto.Pan_Vat_Registration == null)
                {
                    user.Pan_Vat_Registration = null;
                }
                else
                {
                    user.Pan_Vat_Registration = await uploadImage.Upload(userDto.Pan_Vat_Registration, userDto.Company_Name);
                }
                if (userDto.Company_Registration == null)
                {
                    user.Company_Registration = null;
                }
                else
                {
                    user.Company_Registration = await uploadImage.Upload(userDto.Company_Registration, userDto.Company_Name);
                }
                if (userDto.Bank_credit_letter == null)
                {
                    user.Bank_credit_letter = null;
                }
                else
                {
                    user.Bank_credit_letter = await uploadImage.Upload(userDto.Bank_credit_letter, userDto.Company_Name);
                }


                //if (userDto.Experienced_document == null)
                //{
                //    user.Experienced_document = null;
                //}
                //else
                //{
                //    foreach (var file in userDto.Experienced_document)
                //    {
                //        user.Experienced_document.Add(new UserExperienceDocEntity
                //        {
                //            Experienced_doc = await uploadImage.Upload(file, userDto.Company_Name, file.Name)
                //        }
                //        ); 
                //    }
                //}
                
                return UserEntityToDto(await userRepository.AddUser(user, userDto.Experienced_document));
            }
            catch (Exception ex)
            {    

                throw ex;

            }
        }

        public IEnumerable<GetUserDto> GetUser(string search)
        {
            return UserEntityListToDto(userRepository.GetAllUser(search));
        }

        public GetUserDto GetUserDetail(int id)
        {
            return UserEntityToDto(userRepository.GetUserDetail(id));
        }

        public async Task<GetUserDto> SignUp(SignUpDto userDto)
        {
            UserEntity user = SignUpDtoEntity(userDto);

            if (userDto.Front_Citizenship == null)
            {
                user.Front_Citizenship = null;
            }
            else
            {
                user.Front_Citizenship = await uploadImage.Upload(userDto.Front_Citizenship, userDto.Company_Name);
            }
            if (userDto.Back_Citizenship == null)
            {
                user.Back_Citizenship = null;
            }
            else
            {
                user.Back_Citizenship = await uploadImage.Upload(userDto.Back_Citizenship, userDto.Company_Name);
            }
            if (userDto.Tax_Clearance == null)
            {
                user.Tax_Clearance = null;
            }
            else
            {
                user.Tax_Clearance = await uploadImage.Upload(userDto.Tax_Clearance, userDto.Company_Name);
            }
            if (userDto.Pan_Vat_Registration == null)
            {
                user.Pan_Vat_Registration = null;
            }
            else
            {
                user.Pan_Vat_Registration = await uploadImage.Upload(userDto.Pan_Vat_Registration, userDto.Company_Name);
            }
            if (userDto.Company_Registration == null)
            {
                user.Company_Registration = null;
            }
            else
            {
                user.Company_Registration = await uploadImage.Upload(userDto.Company_Registration, userDto.Company_Name);
            }
            if (userDto.Bank_credit_letter == null)
            {
                user.Bank_credit_letter = null;
            }
            else
            {
                user.Bank_credit_letter = await uploadImage.Upload(userDto.Bank_credit_letter, userDto.Company_Name);
            }
            return UserEntityToDto(await userRepository.AddUser(user,userDto.Experienced_document));
        }

        public  async Task<GetUserDto> UpdateUserByAdmin(int id, AddUserDto userDto)
        {
            UserEntity user = UserDtoEntity(userDto);

            if (userDto.Front_Citizenship == null)
            {
                user.Front_Citizenship = null;
            }
            else
            {
                user.Front_Citizenship = await uploadImage.Upload(userDto.Front_Citizenship, userDto.Company_Name);
            }
            if (userDto.Back_Citizenship == null)
            {
                user.Back_Citizenship = null;
            }
            else
            {
                user.Back_Citizenship = await uploadImage.Upload(userDto.Back_Citizenship, userDto.Company_Name);
            }
            if (userDto.Tax_Clearance == null)
            {
                user.Tax_Clearance = null;
            }
            else
            {
                user.Tax_Clearance = await uploadImage.Upload(userDto.Tax_Clearance, userDto.Company_Name);
            }
            if (userDto.Pan_Vat_Registration == null)
            {
                user.Pan_Vat_Registration = null;
            }
            else
            {
                user.Pan_Vat_Registration = await uploadImage.Upload(userDto.Pan_Vat_Registration, userDto.Company_Name);
            }
            if (userDto.Company_Registration == null)
            {
                user.Company_Registration = null;
            }
            else
            {
                user.Company_Registration = await uploadImage.Upload(userDto.Company_Registration, userDto.Company_Name);
            }
            if (userDto.Bank_credit_letter == null)
            {
                user.Bank_credit_letter = null;
            }
            else
            {
                user.Bank_credit_letter = await uploadImage.Upload(userDto.Bank_credit_letter, userDto.Company_Name);
            }
            return UserEntityToDto(await userRepository.UpdateUser(id, user, userDto.Experienced_document));
        }

        public async Task<GetUserDto> UpdateUserByUser(int id, SignUpDto userDto)
        {
            UserEntity user = SignUpDtoEntity(userDto);


            if (userDto.Front_Citizenship == null)
            {
                user.Front_Citizenship = null;
            }
            else
            {
                user.Front_Citizenship = await uploadImage.Upload(userDto.Front_Citizenship, userDto.Company_Name);
            }
            if (userDto.Back_Citizenship == null)
            {
                user.Back_Citizenship = null;
            }
            else
            {
                user.Back_Citizenship = await uploadImage.Upload(userDto.Back_Citizenship, userDto.Company_Name);
            }
            if (userDto.Tax_Clearance == null)
            {
                user.Tax_Clearance = null;
            }
            else
            {
                user.Tax_Clearance = await uploadImage.Upload(userDto.Tax_Clearance, userDto.Company_Name);
            }
            if (userDto.Pan_Vat_Registration == null)
            {
                user.Pan_Vat_Registration = null;
            }
            else
            {
                user.Pan_Vat_Registration = await uploadImage.Upload(userDto.Pan_Vat_Registration, userDto.Company_Name);
            }
            if (userDto.Company_Registration == null)
            {
                user.Company_Registration = null;
            }
            else
            {
                user.Company_Registration = await uploadImage.Upload(userDto.Company_Registration, userDto.Company_Name);
            }
            if (userDto.Bank_credit_letter == null)
            {
                user.Bank_credit_letter = null;
            }
            else
            {
                user.Bank_credit_letter = await uploadImage.Upload(userDto.Bank_credit_letter, userDto.Company_Name);
            }

            return UserEntityToDto( await userRepository.UpdateUser(id, user, userDto.Experienced_document));
        }

       
    }
}
