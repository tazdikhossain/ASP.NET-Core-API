using GCCVBUILDER.Models.Entities;
using GCCVBUILDER.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCCVBUILDER.Data;
using System;

[ApiController]
[Route("api/[controller]")]
public class PersonalInfoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PersonalInfoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalInfoDto>>> GetPersonalInfos()
    {
        var personalInfos = await _context.PersonalInfos
            .Include(p => p.Educations)
            .Include(p => p.Experiences)
            .Include(p => p.Skills)
            .Select(p => new PersonalInfoDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Email = p.Email,
                Phone = p.Phone,
                Address = p.Address,
                LinkedInUrl = p.LinkedInUrl,
                GitHubUrl = p.GitHubUrl,
                Educations = p.Educations.Select(e => new EducationDto
                {
                    Id = e.Id,
                    Institution = e.Institution,
                    Degree = e.Degree,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear,
                    Result = e.Result,
                    Duration = e.Duration,
                    Achievement = e.Achievement
                }).ToList(),
                Experiences = p.Experiences.Select(ex => new ExperienceDto
                {
                    Id = ex.Id,
                    CompanyName = ex.CompanyName,
                    JobTitle = ex.JobTitle,
                    StartYear = ex.StartYear,
                    EndYear = ex.EndYear
                }).ToList(),
                Skills = p.Skills.Select(s => new SkillsDto
                {
                    Id = s.Id,
                    Language = s.Language,
                    Reading = s.Reading,
                    Writing = s.Writing,
                    Speaking = s.Speaking
                }).ToList()
            })
            .ToListAsync();

        return Ok(personalInfos);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalInfoDto>> CreatePersonalInfo(PersonalInfoDto personalInfoDto)
    {
        var personalInfo = new PersonalInfo
        {
            FullName = personalInfoDto.FullName,
            Email = personalInfoDto.Email,
            Phone = personalInfoDto.Phone,
            Address = personalInfoDto.Address,
            LinkedInUrl = personalInfoDto.LinkedInUrl,
            GitHubUrl = personalInfoDto.GitHubUrl,
            Educations = personalInfoDto.Educations.Select(e => new Education
            {
                Institution = e.Institution,
                Degree = e.Degree,
                StartYear = e.StartYear,
                EndYear = e.EndYear,
                Result = e.Result,
                Duration = e.Duration,
                Achievement = e.Achievement
            }).ToList(),
            Experiences = personalInfoDto.Experiences.Select(ex => new Experience
            {
                CompanyName = ex.CompanyName,
                JobTitle = ex.JobTitle,
                StartYear = ex.StartYear,
                EndYear = ex.EndYear
            }).ToList(),
            Skills = personalInfoDto.Skills.Select(s => new Skills
            {
                Language = s.Language,
                Reading = s.Reading,
                Writing = s.Writing,
                Speaking = s.Speaking
            }).ToList()
        };

        _context.PersonalInfos.Add(personalInfo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPersonalInfos), new { id = personalInfo.Id }, personalInfoDto);
    }
}
