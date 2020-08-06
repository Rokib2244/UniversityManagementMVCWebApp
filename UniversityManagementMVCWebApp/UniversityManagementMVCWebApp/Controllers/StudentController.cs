using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityManagementMVCWebApp.Manager;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Controllers
{
    public class StudentController : Controller
    {
        private static List<StudentCourseWiseResult> SaveData = new List<StudentCourseWiseResult>();
        private static List<Student> infoData = new List<Student>();
        private static int? keyData;

        DepartmentManager aDepartmentManager = new DepartmentManager();
        StudentManager aStudentManager = new StudentManager();
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Student aStudent)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = aStudentManager.SaveStudent(aStudent);
            }

            ViewBag.Departments = aDepartmentManager.GetAllDepartment();
            return View();
        }

        public ActionResult SaveResult()
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            ViewBag.Grades = aStudentManager.GetAllGrades();
            return View();

        }

        [HttpPost]

        public ActionResult SaveResult(CourseEnroll studentResult)
        {

           
            ViewBag.Students = aStudentManager.GetAllStudents();
            ViewBag.Grades = aStudentManager.GetAllGrades();
            if (ModelState.IsValid)
            {
                ViewBag.Message = aStudentManager.SaveStudentResult(studentResult);
            }

            return View();

        }



        public ActionResult ViewResult()
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            infoData = aStudentManager.GetAllStudents();
            return View();

        }


        public ActionResult GetCoursesByStudent(int Id)
        {
            List<StudentResultView> assign = aStudentManager.GetCoursesByStudent(Id);

            return Json(assign);


        }

        public ActionResult MakePDF()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            //string pdfName = aPatient.BillNo.ToString();
            string pdfName = "result";
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("D:/" + pdfName + ".pdf", FileMode.Create));
            var output = new MemoryStream();

            doc.Open();
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.NORMAL);
            var subStyle = FontFactory.GetFont("Arial", 14, Font.UNDERLINE);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            //PdfPTable aTable =new PdfPTable(4);
            //aTable.AddCell()


            Paragraph header = new Paragraph("International Islamic University, Chittagong", titleFont);
            header.Alignment = Element.ALIGN_CENTER;
            doc.Add(header);


            Paragraph body = new Paragraph("University Management System", bodyFont);
            body.Alignment = Element.ALIGN_CENTER;
            doc.Add(body);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Date: " + DateTime.Now, subTitleFont));
            doc.Add(Chunk.NEWLINE);
            Paragraph infoa = new Paragraph("Student Information", subStyle);
            infoa.Alignment = Element.ALIGN_CENTER;
            doc.Add(infoa);
            doc.Add(Chunk.NEWLINE);

            foreach (var item in infoData)
            {
                if (keyData == item.Id)
                {
                    doc.Add(new Paragraph("Student Name:                    " + item.Name, subTitleFont));
                    doc.Add(new Paragraph("Student Email:                    " + item.Email, subTitleFont));
                    doc.Add(new Paragraph("Student Registration No:    " + item.RegistrationNo, subTitleFont));

                    foreach (var aitem in aDepartments)
                    {
                        if (item.DepartmentId == aitem.ID)
                        {
                            doc.Add(new Paragraph("Student Department:          " + aitem.Name, subTitleFont));
                        }
                    }

                    break;
                }
            }

            infoData = null;
            keyData = null;

            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);


            Paragraph info = new Paragraph("Student Course Wise Result", subStyle);
            info.Alignment = Element.ALIGN_CENTER;
            doc.Add(info);
            doc.Add(Chunk.NEWLINE);




            var orderDetailsTable = new PdfPTable(3);
            orderDetailsTable.HorizontalAlignment = 1;
            orderDetailsTable.SpacingBefore = 10;
            orderDetailsTable.SpacingAfter = 35;
            orderDetailsTable.DefaultCell.Border = PdfPCell.BOX;
            orderDetailsTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


            orderDetailsTable.AddCell(new Phrase("Course Code", boldTableFont));
            orderDetailsTable.AddCell(new Phrase("Course Name", boldTableFont));
            orderDetailsTable.AddCell(new Phrase("Grade", boldTableFont));


            int sl = 1;
            double totalFee = 0;
            if (SaveData.Count != 0 || SaveData == null)
            {
                foreach (var item in SaveData)
                {

                    orderDetailsTable.AddCell(item.Code);
                    orderDetailsTable.AddCell(item.Name);
                    orderDetailsTable.AddCell(item.CourseGrade);

                }
            }

            SaveData = new List<StudentCourseWiseResult>();
            orderDetailsTable.HorizontalAlignment = Element.ALIGN_CENTER;
            doc.Add(orderDetailsTable);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);


            // Add ending message
            Paragraph endingMessage = new Paragraph("All Rights Reserved University Authority",
                endingMessageFont);
            endingMessage.Alignment = Element.ALIGN_CENTER;
            doc.Add(endingMessage);

            doc.Close();
            string fillName = "D:/" + pdfName + ".pdf";
            System.Diagnostics.Process.Start(fillName);

            return RedirectToAction("ViewResult", "Student");

        }



        public ActionResult GetCoursesResultByStudent(int Id)
        {
            List<StudentCourseWiseResult> result = aStudentManager.GetCoursesResultByStudent(Id);
            SaveData = result;
            keyData = Id;


            return Json(result);
        }
	}
}