using ConsumingAnAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConsumingAnAPI.Contracts
{
    public interface ITodos
    {
        List<ToDo> Get();
        ToDo GetById(int id);
    }
}
