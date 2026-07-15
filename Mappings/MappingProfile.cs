using AutoMapper;
using ELearning.Api.DTOs;
using ELearning.Api.Features.Courses.Commands.CreateCourse;
using ELearning.Api.Features.Courses.Commands.UpdateCourse;
using ELearning.Api.Features.Courses.DTOs;
using ELearning.Api.Features.Lessons.Commands.CreateLesson;
using ELearning.Api.Features.Lessons.DTOs;
using ELearning.Api.Models;

namespace ELearning.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Course
        CreateMap<Course, CourseResponseDto>();

        CreateMap<CourseCreateDto, Course>();

        CreateMap<CourseUpdateDto, Course>();

        CreateMap<CreateCourseCommand, Course>();

        CreateMap<UpdateCourseCommand, Course>();

        // Lesson
        CreateMap<Lesson, LessonResponseDto>();

        CreateMap<LessonCreateDto, Lesson>();

        CreateMap<LessonUpdateDto, Lesson>();

        CreateMap<CreateLessonCommand, Lesson>()
            .ForMember(dest => dest.FileData, opt => opt.Ignore())
            .ForMember(dest => dest.FileName, opt => opt.Ignore())
            .ForMember(dest => dest.ContentType, opt => opt.Ignore())
            .ForMember(dest => dest.FileSize, opt => opt.Ignore())
            .ForMember(dest => dest.Course, opt => opt.Ignore());
    }
}