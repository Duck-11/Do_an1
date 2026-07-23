
using do_an_Nhom7.Controllers;
using do_an_Nhom7.Data;
using do_an_Nhom7.Models;
using do_an_Nhom7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HocVienController : CoSoController
{

    public HocVienController(EnglishCenterDbContext db) : base(db)
    {
    }

    public IActionResult TongQuan()
    {
        var auth = RequireRole("Student");
        if (auth != null) return auth;

        var student = CurrentStudent;
        var studentId = student?.Id ?? 0;
        var enrollments = Db.Enrollments.AsNoTracking()
            .Where(x => x.StudentId == studentId)
            .OrderByDescending(x => x.RegisteredAt)
            .ToList();
        var courseIds = enrollments.Select(x => x.CourseId).Distinct().ToList();
        var classIds = enrollments.Where(x => x.ClassId.HasValue).Select(x => x.ClassId!.Value).ToList();
        ViewBag.Courses = Db.Courses.AsNoTracking().Where(x => courseIds.Contains(x.Id)).ToList();
        ViewBag.Classes = Db.Classes.AsNoTracking().Where(x => classIds.Contains(x.Id)).ToList();
        ViewBag.Payments = Db.Payments.AsNoTracking().Where(x => x.StudentId == studentId).ToList();
        return View(enrollments);
    }

    public IActionResult LichHoc()
    {
        var auth = RequireRole("Student");
        if (auth != null) return auth;

        var student = CurrentStudent;
        var studentId = student?.Id ?? 0;
        var classIds = Db.Enrollments
            .AsNoTracking()
            .Where(x => x.StudentId == studentId && x.Status == EnglishCenterStore.EnrollmentApproved && x.ClassId.HasValue)
            .Select(x => x.ClassId!.Value)
            .ToHashSet();
        var classes = Db.Classes.AsNoTracking().Where(x => classIds.Contains(x.Id)).ToList();
        var courseIds = classes.Select(x => x.CourseId).Distinct().ToList();
        var teacherIds = classes.Select(x => x.TeacherId).Distinct().ToList();
        ViewBag.Courses = Db.Courses.AsNoTracking().Where(x => courseIds.Contains(x.Id)).ToList();
        ViewBag.Teachers = Db.Teachers.AsNoTracking().Where(x => teacherIds.Contains(x.Id)).ToList();
        return View(classes);
    }

    public IActionResult DiemSo()
    {
        var auth = RequireRole("Student");
        if (auth != null) return auth;

        var student = CurrentStudent;
        var studentId = student?.Id ?? 0;
        var scores = Db.Scores.AsNoTracking().Where(x => x.StudentId == studentId).ToList();
        var classIds = scores.Select(x => x.ClassId).Distinct().ToList();
        var classes = Db.Classes.AsNoTracking().Where(x => classIds.Contains(x.Id)).ToList();
        var courseIds = classes.Select(x => x.CourseId).Distinct().ToList();
        ViewBag.Classes = classes;
        ViewBag.Courses = Db.Courses.AsNoTracking().Where(x => courseIds.Contains(x.Id)).ToList();
        return View(scores);
    }

    public IActionResult HocPhi()
    {
        var auth = RequireRole("Student");
        if (auth != null) return auth;

        var student = CurrentStudent;
        var studentId = student?.Id ?? 0;
        var enrollments = Db.Enrollments.AsNoTracking().Where(x => x.StudentId == studentId).ToList();
        var courseIds = enrollments.Select(x => x.CourseId).Distinct().ToList();
        ViewBag.Enrollments = enrollments;
        ViewBag.Courses = Db.Courses.AsNoTracking().Where(x => courseIds.Contains(x.Id)).ToList();
        ViewBag.PaymentTransactions = Db.PaymentTransactions.AsNoTracking()
            .Where(x => x.StudentId == studentId)
            .OrderByDescending(x => x.PaidAt)
            .ToList();
        return View(Db.Payments.AsNoTracking().Where(x => x.StudentId == studentId).ToList());
    }
}
