using System.Diagnostics;
using Domain;
using Microsoft.Extensions.Configuration;

namespace Application.Utils;

public static class Constants
{
    public static readonly double PRICE_PER_KILOMETER = 3;
    public static readonly Address GENERAL_ADDRESS = new Address("Horsens", 8700, "Banegårdsgade 2,");
}