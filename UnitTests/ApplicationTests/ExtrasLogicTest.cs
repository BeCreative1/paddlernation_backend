using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using xUnit.Utils;

namespace xUnit.ApplicationTests;

public class ExtrasLogicTest : DbTestBaseClass
{
    private readonly ExtrasLogic ExtrasLogic;
    private readonly IExtrasDao ExtrasDao;
}