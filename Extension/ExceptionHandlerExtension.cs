using MeroBolee.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee
{
    public static class ExceptionHandlerExtension
    {
        public static ResponseMsg HandleException(this Exception exception)
        {
            ResponseMsg response = new ResponseMsg();
            response.statusCode = "500";

            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                // A custom exception of yours for concurrency issues
                //throw new ConcurrencyException();
                response.Message = concurrencyEx.Message;

            }
            else if (exception is DbUpdateException dbUpdateEx)
            {
                response.Message = dbUpdateEx.InnerException.Message.Split("'.")[1].Split(Environment.NewLine)[0];
                
                //if (dbUpdateEx.InnerException != null
                //        && dbUpdateEx.InnerException != null)
                //{
                //    if (dbUpdateEx.InnerException is DbException sqlException)
                //    {
                //        switch (sqlException.Errors)
                //        {
                //            case 2627:  // Unique constraint error
                //                response.Message = "Unique constraint error";
                //                break;
                //            case 547:   // Constraint check violation
                //            case 2601:  // Duplicated key row error
                //                        // Constraint violation exception
                //                        // A custom exception of yours for concurrency issues
                //                        //throw new ConcurrencyException();
                //                response.Message = "Some message";
                //                break;
                //            default:
                //                // A custom exception of yours for other DB issues
                //                //throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
                //                response.Message = "Some other message";
                //                break;
                //        }
                //    }

                    //throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
                //}
            }
            else
            {
                response.Message = exception.Message;
            }


            //response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
            //return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            return response;
            // If we're here then no exception has been thrown
            // So add another piece of code below for other exceptions not yet handled...
        }
    }
}
