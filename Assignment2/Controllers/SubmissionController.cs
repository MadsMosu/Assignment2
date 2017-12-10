using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Microsoft.AspNetCore.Authorization;
using MyClassLibrary;


namespace Assignment2.Controllers
{

    public class SubmissionController : Controller
    {
        private ISerialNumbersData _serialNumbersData;
        private ISubmissionData _submissionData;

        public SubmissionController(ISerialNumbersData serialNumberData, ISubmissionData submissionData)
        {
            _serialNumbersData = serialNumberData;
            _submissionData = submissionData;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Submission inputData)
        {           
            if (ModelState.IsValid && _serialNumbersData.VerifySerialNumber(inputData.SerialNumb) && _submissionData.VerifyNewSubmission(inputData.SerialNumb))
            {
                var submission = new Submission
                {
                    FirstName = inputData.FirstName,
                    SurName = inputData.SurName,
                    Email = inputData.Email,
                    PhoneNumb = inputData.PhoneNumb,
                    DateOfBirth = inputData.DateOfBirth,
                    SerialNumb = inputData.SerialNumb
                };
                _submissionData.AddSubmission(submission);
            }
            return View();
        }

        [HttpGet("admin/submissions")]
        public IActionResult AdminSubmissions()
        {
            if (_serialNumbersData.GetAll().Any())
            {
                ViewData["submissions"] = _submissionData.GetAll(); 
            }
            
            return View();
        }


        [HttpGet("admin/serialnumbers")]
        public IActionResult AdminSerialNumbers()
        {
            ViewData["serialnumbers"] = _serialNumbersData.GetAll();

            return View();
        }
    }
}