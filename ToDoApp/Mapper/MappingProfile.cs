namespace ToDoApp.Mapper
{
    using AutoMapper;
    using ToDoApp.DTOs;
    using ToDoApp.Data;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItemCreate, TaskItem>();
            CreateMap<TaskItem, TaskItemDetail>();
        }
    }

}