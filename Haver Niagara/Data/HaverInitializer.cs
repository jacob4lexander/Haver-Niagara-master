using Haver_Niagara.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using System.Diagnostics;
using System.Text;
namespace Haver_Niagara.Data
{
    public static class HaverInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            HaverNiagaraDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<HaverNiagaraDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //context.Database.Migrate();

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Admin",
                        LastName = "Powers",
                        Email = "admin@outlook.com"
                    },
                    new Employee
                    {
                        FirstName = "Quality",
                        LastName = "User",
                        Email = "qualityrepresentative@outlook.com"
                    },
                    new Employee
                    {
                        FirstName = "Engineer",
                        LastName = "User",
                        Email = "engineer@outlook.com"
                    },
                    new Employee
                    {
                        FirstName = "Operations",
                        LastName = "User",
                        Email = "operations@outlook.com"
                    },
                    new Employee
                    {
                        FirstName = "Procurement",
                        LastName = "User",
                        Email = "procurement@outlook.com"
                    },
                    new Employee
                    {
                        FirstName = "Finance",
                        LastName = "User",
                        Email = "finance@outlook.com"
                    });
                context.SaveChanges();
            }
            if (!context.Defects.Any())
            {
                var defects = new List<Defect>
                    {
                        new Defect {ID = 1, Name = "Design Error (Drawing)"},
                        new Defect {ID = 2, Name = "Holes not tapped"},
                        new Defect {ID = 3, Name = "Incorrect dimensions"},
                        new Defect {ID = 4, Name = "Incorrect hardware"},
                        new Defect {ID = 5, Name = "Incorrect hole (size,locations,missing)"},
                        new Defect {ID = 6, Name = "Incorrect thread size"},
                        new Defect {ID = 7, Name = "Not Painted"},
                        new Defect {ID = 8, Name = "Poor Paint finish"},
                        new Defect {ID = 9, Name = "Poor quality surface finish"},
                        new Defect {ID = 10, Name = "Poor Weld quality"},
                        new Defect {ID = 11, Name = "Incorrect fit"},
                        new Defect {ID = 12, Name = "Incorrect weld size"},
                        new Defect {ID = 13, Name = "Missing Items"},
                        new Defect {ID = 14, Name = "Broken / Twisted Wires"},
                        new Defect {ID = 15, Name = "Out of Crimp"},
                        new Defect {ID = 16, Name = "Incorrect Specification"},
                        new Defect {ID = 17, Name = "Incorrect Hook / Hook Orientation"},
                        new Defect {ID = 18, Name = "Incorrect Center Hole Punching"},
                        new Defect {ID = 19, Name = "Missing Center Hole Punching"},
                        new Defect {ID = 20, Name = "Incorrect hardware installation"},
                        new Defect {ID = 21, Name = "Incorrect labelling"},
                        new Defect {ID = 22, Name = "Drawing not updated"},
                        new Defect {ID = 23, Name = "Incorrect material"},
                        new Defect {ID = 24, Name = "Delivery Quality"},
                        new Defect {ID = 25, Name = "Finishing error (M.W. STC)"},
                        new Defect {ID = 26, Name = "Incorrect component (FMP package)"},
                    };
                context.Defects.AddRange(defects);
                context.SaveChanges();
            }

            // SUPPLIERS

            if (!context.Suppliers.Any())
            {
                context.Suppliers.AddRange(
                new Supplier { ID = 1, Name = "AJAX TOCCO" },
                new Supplier { ID = 2, Name = "HINGSTON METAL FABRICATORS" },
                new Supplier { ID = 3, Name = "HOTZ ENVIRONMENTAL SERVICES" },
                new Supplier { ID = 4, Name = "BLACK CREEK METAL" },
                new Supplier { ID = 5, Name = "POLYMER EXTRUSIONS INC" },
                new Supplier { ID = 6, Name = "DON CASSELMAN & SON LTD" },
                new Supplier { ID = 7, Name = "WAFIOS MACHINERY CORPORATION" },
                new Supplier { ID = 8, Name = "C.H.R. INDUSTRIES INC." },
                new Supplier { ID = 9, Name = "PHILPOTT RUBBER COMPANY" },
                new Supplier { ID = 10, Name = "BALDOR ELECTRIC COMPANY" },
                new Supplier { ID = 11, Name = "LUDOWICI SCREENS, INC." },
                new Supplier { ID = 12, Name = "ESMET INC" },
                new Supplier { ID = 13, Name = "SECURITY STEEL SUPPLY CO." },
                new Supplier { ID = 14, Name = "HOIST LIFTRUCK MFG INC" },
                new Supplier { ID = 15, Name = "MIDWESTERN INDUSTRIES INC." },
                new Supplier { ID = 16, Name = "FIRESTONE IND. PROD." },
                new Supplier { ID = 17, Name = "STIMPSON COMPANY INC." },
                new Supplier { ID = 18, Name = "GLENRIDGE MACHINE CO." },
                new Supplier { ID = 19, Name = "SIFCO FORGE GROUP" },
                new Supplier { ID = 20, Name = "JOHNSON RUBBER COMPANY" },
                new Supplier { ID = 21, Name = "MIDWEST BRASS FORGING COMPANY" },
                new Supplier { ID = 22, Name = "SIEMENS WATER TECHNOLOGIES" },
                new Supplier { ID = 23, Name = "SAMSCREEN INC" },
                new Supplier { ID = 24, Name = "BETTCHER MANUFACTURING LLC" },
                new Supplier { ID = 25, Name = "UNIVERSAL WIRE CLOTH CO." },
                new Supplier { ID = 26, Name = "UNIQUE SYSTEMS" },
                new Supplier { ID = 27, Name = "RAF FLUID POWER" },
                new Supplier { ID = 28, Name = "DEKALB FORGE COMPANY" },
                new Supplier { ID = 29, Name = "CORDILLERA" },
                new Supplier { ID = 30, Name = "A.W. BOHANAN COMPANY" },
                new Supplier { ID = 31, Name = "SIGNAL TECHNOLOGY SYSTEMS" },
                new Supplier { ID = 32, Name = "MCDA INC" },
                new Supplier { ID = 33, Name = "EDWARD W DANIEL CO" },
                new Supplier { ID = 34, Name = "ALCOA FASTENING SYSTEMS" },
                new Supplier { ID = 35, Name = "WESTERN CAST PARTS" },
                new Supplier { ID = 36, Name = "TESCO-THE ENGINEERED SALES CO." },
                new Supplier { ID = 37, Name = "MCMASTER-CARR" },
                new Supplier { ID = 38, Name = "DRACO SPRING MFG. CO." },
                new Supplier { ID = 39, Name = "VALLEY EQUIPMENT COMPANY INC." },
                new Supplier { ID = 40, Name = "OVERLY HAUTZ MOTOR BASE CO." },
                new Supplier { ID = 41, Name = "BPG/BRANDON PRODUCTS GROUP" },
                new Supplier { ID = 42, Name = "CAST METALS INC." },
                new Supplier { ID = 43, Name = "TEMA ISENMANN, INC." },
                new Supplier { ID = 44, Name = "VALLEY RUBBER, LLC" },
                new Supplier { ID = 45, Name = "COILING TECHNOLOGIES INC" },
                new Supplier { ID = 46, Name = "WARD INDUSTRIAL EQUIPMENT" },
                new Supplier { ID = 47, Name = "E S FOX LTD" },
                new Supplier { ID = 48, Name = "HENDRICK MANUFACTURING" },
                new Supplier { ID = 49, Name = "DIAMOND WIRE SPRING CO." }

                );
                context.SaveChanges();
            }

            // PART NAME

            if (!context.PartNames.Any())
            {
                context.PartNames.AddRange(
                new PartName { ID = 1, Name = "Wheels" },
                new PartName { ID = 2, Name = "Mounting Plate" },
                new PartName { ID = 3, Name = "Wires" },
                new PartName { ID = 4, Name = "Steel Panels" },
                new PartName { ID = 5, Name = "Nuts" },
                new PartName { ID = 6, Name = "Bolts" },
                new PartName { ID = 7, Name = "Screws" },
                new PartName { ID = 8, Name = "Rivets" },
                new PartName { ID = 9, Name = "Washers" },
                new PartName { ID = 10, Name = "Anchors" },
                new PartName { ID = 11, Name = "Nails" },
                new PartName { ID = 12, Name = "Clips" }

                );
                context.SaveChanges();
            }

            if (!context.SAPNumbers.Any())
            {
                context.SAPNumbers.AddRange(
                new SAPNumber { ID = 1, Number = 207956254 },
                new SAPNumber { ID = 2, Number = 207956203 },
                new SAPNumber { ID = 3, Number = 207956307 },
                new SAPNumber { ID = 4, Number = 207956240 },
                new SAPNumber { ID = 5, Number = 207956299 },
                new SAPNumber { ID = 6, Number = 207956248 },
                new SAPNumber { ID = 7, Number = 207956237 },
                new SAPNumber { ID = 8, Number = 207956212 },
                new SAPNumber { ID = 9, Number = 207956241 },
                new SAPNumber { ID = 10, Number = 207956288 },
                new SAPNumber { ID = 11, Number = 207956205 },
                new SAPNumber { ID = 12, Number = 207956270 }

                );
                context.SaveChanges();
            }

            // PARTS: ONE FOR EA. NCR

            if (!context.Parts.Any())
            {
                context.Parts.AddRange(
                new Part
                {
                    ID = 1,
                    //Name = "Wheels",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 1),
                    ProductNumber = 4500730930,
                    QuantityRecieved = 20,
                    QuantityDefect = 20,
                    Description = "Replacement wheels",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 1),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 1),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 1, DefectID = 1},
                    }
                },
                new Part
                {
                    ID = 2,
                    //Name = "Wires",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 2),
                    ProductNumber = 206547333,
                    QuantityRecieved = 10,
                    QuantityDefect = 10,
                    Description = "Replacement wires",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 2),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 2, DefectID = 2},
                    }
                },
                new Part
                {
                    ID = 3,
                    //Name = "Steel Panels",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 3),
                    ProductNumber = 207843292,
                    QuantityRecieved = 8,
                    QuantityDefect = 2,
                    Description = "Steel panels for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 3),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 3, DefectID = 3},
                    }
                },
                new Part
                {
                    ID = 4,
                    //Name ="Bolts",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 4),
                    ProductNumber = 205231782,
                    QuantityRecieved = 100,
                    QuantityDefect = 100,
                    Description = "Bolts for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 3),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 4),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 4, DefectID = 4},
                    }
                },
                new Part
                {
                    ID = 5,
                    //Name ="Nuts",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 5),
                    ProductNumber = 209031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 100,
                    Description = "Nuts for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 5),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 5, DefectID = 5},
                    }
                },
                new Part
                {
                    ID = 6,
                    //Name = "Screws",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 6),
                    ProductNumber = 209031296,
                    QuantityRecieved = 200,
                    QuantityDefect = 10,
                    Description = "Screws for repairs.",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 6),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 6, DefectID = 6},
                    }
                },
                new Part
                {
                    ID = 7,
                    //Name = "Rivets",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 7),
                    ProductNumber = 209031299,
                    QuantityRecieved = 100,
                    QuantityDefect = 40,
                    Description = "Rivets for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 7),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 7, DefectID = 7},
                    }
                },
                new Part
                {
                    ID = 8,
                    //Name = "Washers",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 8),
                    ProductNumber = 244110399,
                    PartNumber = 11843399,
                    QuantityRecieved = 50,
                    QuantityDefect = 1,
                    Description = "Washers for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 8),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 8, DefectID = 8},
                    }
                },
                new Part
                {
                    ID = 9,
                    //Name = "Anchors",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 9),
                    ProductNumber = 204231293,
                    QuantityRecieved = 10,
                    QuantityDefect = 1,
                    Description = "Anchors for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 9),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 9, DefectID = 9},
                    }
                },
                new Part
                {
                    ID = 10,
                    //Name = "Nails",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 10),
                    ProductNumber = 212031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 54,
                    Description = "Nails for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 10),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 10, DefectID = 10},
                    }
                },
                new Part
                {
                    ID = 11,
                    //Name = "Clips",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 11),
                    ProductNumber = 219031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 29,
                    Description = "Clips for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 11),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 11, DefectID = 11},
                    }
                },
                new Part
                {
                    ID = 12,
                    //Name = "Wheels",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 12),
                    ProductNumber = 208475893,
                    QuantityRecieved = 20,
                    QuantityDefect = 20,
                    Description = "Replacement wheels",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 1),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 12),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 12, DefectID = 12},
                    }
                },
                new Part
                {
                    ID = 13,
                    //Name = "Wires",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 1),
                    ProductNumber = 206547333,
                    QuantityRecieved = 10,
                    QuantityDefect = 10,
                    Description = "Replacement wires",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 1),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 13, DefectID = 13},
                    }
                },
                new Part
                {
                    ID = 14,
                    //Name = "Steel Panels",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 2),
                    ProductNumber = 207843292,
                    QuantityRecieved = 8,
                    QuantityDefect = 2,
                    Description = "Steel panels for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 2),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 14, DefectID = 14},
                    }
                },
                new Part
                {
                    ID = 15,
                    //Name = "Bolts",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 3),
                    ProductNumber = 205231782,
                    QuantityRecieved = 100,
                    QuantityDefect = 100,
                    Description = "Bolts for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 3),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 3),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 15, DefectID = 15},
                    }
                },
                new Part
                {
                    ID = 16,
                    //Name = "Nuts",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 4),
                    ProductNumber = 209031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 100,
                    Description = "Nuts for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 4),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 16, DefectID = 16},
                    }
                },
                new Part
                {
                    ID = 17,
                    //Name = "Screws",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 5),
                    ProductNumber = 209031296,
                    QuantityRecieved = 200,
                    QuantityDefect = 10,
                    Description = "Screws for repairs.",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 5),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 17, DefectID = 17},
                    }
                },
                new Part
                {
                    ID = 18,
                    //Name = "Rivets",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 6),
                    ProductNumber = 209031299,
                    QuantityRecieved = 100,
                    QuantityDefect = 40,
                    Description = "Rivets for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 6),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 18, DefectID = 18},
                    }
                },
                new Part
                {
                    ID = 19,
                    //Name = "Washers",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 7),
                    ProductNumber = 244110399,
                    QuantityRecieved = 50,
                    QuantityDefect = 1,
                    Description = "Washers for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 7),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 19, DefectID = 19},
                    }
                },
                new Part
                {
                    ID = 20,
                    //Name = "Anchors",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 8),
                    ProductNumber = 204231293,
                    QuantityRecieved = 10,
                    QuantityDefect = 1,
                    Description = "Anchors for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 8),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 20, DefectID = 20},
                    }
                },
                new Part
                {
                    ID = 21,
                    //Name = "Nails",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 9),
                    ProductNumber = 212031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 54,
                    Description = "Nails for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 9),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 21, DefectID = 21},
                    }
                },
                new Part
                {
                    ID = 22,
                    //Name = "Clips",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 10),
                    ProductNumber = 219031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 29,
                    Description = "Clips for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 10),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 22, DefectID = 22},
                    }
                },
                new Part
                {
                    ID = 23,
                    //Name = "Anchors",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 11),
                    ProductNumber = 204231293,
                    QuantityRecieved = 10,
                    QuantityDefect = 1,
                    Description = "Anchors for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 11),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 23, DefectID = 23},
                    }
                },
                new Part
                {
                    ID = 24,
                    //Name = "Screws",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 12),
                    PartNumber = 23873292,
                    ProductNumber = 209031296,
                    QuantityRecieved = 200,
                    QuantityDefect = 10,
                    Description = "Screws for repairs.",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 12),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 24, DefectID = 24}

                    }
                },
                new Part
                {
                    ID = 25,
                    //Name = "Wires",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 1),
                    PartNumber = 22843321,
                    ProductNumber = 206547333,
                    QuantityRecieved = 10,
                    QuantityDefect = 10,
                    Description = "Replacement wires",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 1),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {DefectID = 2, PartID = 25}
                    }
                },
                new Part
                {
                    ID = 26,
                    //Name = "Nuts",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 2),
                    PartNumber = 29111323,
                    ProductNumber = 209031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 100,
                    Description = "Nuts for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 2),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {DefectID = 3, PartID = 26}
                    }
                },
                new Part
                {
                    ID = 27,
                    //Name = "Screws",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 3),
                    PartNumber = 26833212,
                    ProductNumber = 209031296,
                    QuantityRecieved = 200,
                    QuantityDefect = 10,
                    Description = "Screws for repairs.",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 3),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 27, DefectID = 1},
                    }
                },
                new Part
                {
                    ID = 28,
                    //Name = "Rivets",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 4),
                    PartNumber = 12873211,
                    ProductNumber = 209031299,
                    QuantityRecieved = 100,
                    QuantityDefect = 40,
                    Description = "Rivets for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 4),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 28, DefectID = 2},
                    }
                },
                new Part
                {
                    ID = 29,
                    //Name = "Washers",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 5),
                    PartNumber = 13853231,
                    ProductNumber = 244110399,
                    QuantityRecieved = 50,
                    QuantityDefect = 1,
                    Description = "Washers for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 5),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 29, DefectID = 3},
                    }
                },
                new Part
                {
                    ID = 30,
                    //Name = "Anchors",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 6),
                    PartNumber = 35873222,
                    ProductNumber = 204231293,
                    QuantityRecieved = 10,
                    QuantityDefect = 1,
                    Description = "Anchors for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 6),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 30, DefectID = 4},
                    }
                },
                new Part
                {
                    ID = 31,
                    //Name = "Nails",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 7),
                    PartNumber = 67422111,
                    ProductNumber = 212031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 54,
                    Description = "Nails for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 7),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 31, DefectID = 5},
                    }
                },
                new Part
                {
                    ID = 32,
                    //Name = "Clips",
                    PartNumber = 33263892,
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 8),
                    ProductNumber = 219031293,
                    QuantityRecieved = 200,
                    QuantityDefect = 29,
                    Description = "Clips for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 8),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 32, DefectID = 6},
                    }
                },
                new Part
                {
                    ID = 33,
                    //Name = "Anchors",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 9),
                    ProductNumber = 204231293,
                    QuantityRecieved = 10,
                    QuantityDefect = 1,
                    Description = "Anchors for repairs",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 9),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 33, DefectID = 7},
                    }
                },
                new Part
                {
                    ID = 34,
                    //Name = "Screws",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 10),
                    ProductNumber = 209031296,
                    QuantityRecieved = 200,
                    QuantityDefect = 10,
                    Description = "Screws for repairs.",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 10),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 34, DefectID = 8},
                    }
                },
                new Part
                {
                    ID = 35,
                    //Name = "Wires",
                    PartName = context.PartNames.FirstOrDefault(c => c.ID == 11),
                    ProductNumber = 206547333,
                    QuantityRecieved = 10,
                    QuantityDefect = 10,
                    Description = "Replacement wires",
                    Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                    SAPNumber = context.SAPNumbers.FirstOrDefault(c => c.ID == 11),
                    //PurchaseNumber = 4500730930,
                    SalesOrder = "Stock",
                    DefectLists = new List<DefectList>
                    {
                        new DefectList {PartID = 35, DefectID = 9},
                    }
                });
                context.SaveChanges();
            }

            // MEDIA

            if (!context.Medias.Any())
            {
                //Random Pictures of Defects
                byte[] badPaint1 = File.ReadAllBytes("TemporaryImages/badpaint.jpg");
                byte[] badPaint2 = File.ReadAllBytes("TemporaryImages/badpaint2.jpg");
                byte[] badWeld = File.ReadAllBytes("TemporaryImages/badWeld.jpg");
                byte[] bluePrint1 = File.ReadAllBytes("TemporaryImages/blueprint1.jpg");
                byte[] bluePrint2 = File.ReadAllBytes("TemporaryImages/blueprint2.jpg");
                byte[] faultybolt = File.ReadAllBytes("TemporaryImages/faultybolt.jpg");
                byte[] faultyrope = File.ReadAllBytes("TemporaryImages/faultyrope.jpg");
                byte[] faultyPrint = File.ReadAllBytes("TemporaryImages/tube.jpg");
                byte[] tube = File.ReadAllBytes("TemporaryImages/faultyPrint.jpg");

                //To have an NCR with multiple pictures assigned, simply create a new media
                //And Under Part, set it to the same ID, (see the first 2)..

                context.Medias.AddRange(
                    new Media
                    {
                        ID = 1,
                        Content = bluePrint1,
                        Description = "Faulty Blue Print 1",
                        MimeType = "image/jpg",
                        Links = "https://example.com/1bluePrint_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 1)
                    },
                    new Media
                    {
                        ID = 2,
                        Content = bluePrint2,
                        Description = "Faulty Blue Print 2",
                        MimeType = "image/jpg",
                        Links = "https://example.com/2bluePrint_video2",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 1)
                    },
                    new Media
                    {
                        ID = 3,
                        Content = badPaint1,
                        Description = "Bad Paint Finish 1",
                        MimeType = "image/jpg",
                        Links = "https://example.com/3badPaint_gif",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 2)
                    },
                    new Media
                    {
                        ID = 4,
                        Content = badPaint2,
                        Description = "Bad Paint Finish 2",
                        MimeType = "image/jpg",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 2)
                    },
                    new Media
                    {
                        ID = 5,
                        Content = badWeld,
                        Description = "Poorly done weld",
                        MimeType = "image/jpg",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 3)
                    },
                    new Media
                    {
                        ID = 6,
                        Content = faultybolt,
                        Description = "faulty bolt",
                        MimeType = "image/jpg",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 4)
                    },
                    new Media
                    {
                        ID = 7,
                        Content = faultyrope,
                        Description = "faulty rope",
                        MimeType = "image/jpg",
                        Links = "https://example.com/7faultyRope_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 5)
                    },
                    new Media
                    {
                        ID = 8,
                        Content = faultyPrint,
                        Description = "faulty print",
                        MimeType = "image/jpg",
                        Links = "https://example.com/8faultPrint_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 6)
                    },
                    new Media
                    {
                        ID = 9,
                        Content = tube,
                        Description = "Poor tube finish",
                        MimeType = "image/jpg",
                        Links = "https://example.com/9poorTubeFinish_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 7)
                    },
					new Media
					{
						ID = 10,
						Content = tube,
						Description = "Poor Finish",
						MimeType = "image/jpg",
						Links = "C:\\Users\\Alex\\Dropbox\\ncr_2017-001-1.mp4",
						Part = context.Parts.FirstOrDefault(p => p.ID == 24)
					},
					new Media
					{
						ID = 11,
						Links = "C:\\Users\\Alex\\Dropbox\\ncr_2017-001-2.mp4",
						Part = context.Parts.FirstOrDefault(p => p.ID == 24)
					},
					new Media
					{
						ID = 12,
						Content = badPaint1,
						Description = "Bad Paint Finish",
						MimeType = "image/jpg",
						Links = "C:\\Users\\Jacob\\Dropbox\\ncr_2011-002-1.mp4",
						Part = context.Parts.FirstOrDefault(p => p.ID == 25)
					},
					new Media
					{
						ID = 13,
						Content = badPaint2,
						Description = "Bad Paint Finish",
						MimeType = "image/jpg",
						Links = "C:\\Users\\Jacob\\Dropbox\\ncr_2011-002-2.mp4",
						Part = context.Parts.FirstOrDefault(p => p.ID == 25)
					},
					new Media
                    {
                        ID = 14,
                        Content = tube,
                        Description = "Poor tube finish",
                        MimeType = "image/jpg",
                        Links = "https://example.com/9poorTubeFinish_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 9)
                    },
                    new Media
                    {
                        ID = 15,
                        Content = bluePrint1,
                        Description = "blue print",
                        MimeType = "image/jpg",
                        Links = "https://example.com/9poorTubeFinish_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 10)
                    },
                    new Media
					{
						ID = 16,
						Content = badPaint2,
						Description = "Bad Paint Finish",
						MimeType = "image/jpg",
						Links = "C:\\Users\\Jacob\\Dropbox\\ncr_2011-002-2.mp4",
						Part = context.Parts.FirstOrDefault(p => p.ID == 12)
					},
					new Media
                    {
                        ID = 17,
                        Content = tube,
                        Description = "Poor tube finish",
                        MimeType = "image/jpg",
                        Links = "https://example.com/9poorTubeFinish_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 13)
                    },
                    new Media
                    {
                        ID = 18,
                        Content = bluePrint1,
                        Description = "blue print",
                        MimeType = "image/jpg",
                        Links = "https://example.com/9poorTubeFinish_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 14)
                    },
                    new Media
                    {
                        ID = 19,
                        Content = faultybolt,
                        Description = "faulty bolt",
                        MimeType = "image/jpg",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 15)
                    },
                    new Media
                    {
                        ID = 20,
                        Content = faultyrope,
                        Description = "faulty rope",
                        MimeType = "image/jpg",
                        Links = "https://example.com/7faultyRope_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 16)
                    },
                    new Media
                    {
                        ID = 21,
                        Content = faultyPrint,
                        Description = "faulty print",
                        MimeType = "image/jpg",
                        Links = "https://example.com/8faultPrint_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 17)
                    },
                    new Media
                    {
                        ID = 22,
                        Content = faultybolt,
                        Description = "faulty bolt",
                        MimeType = "image/jpg",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 21)
                    },
                    new Media
                    {
                        ID = 23,
                        Content = faultyrope,
                        Description = "faulty rope",
                        MimeType = "image/jpg",
                        Links = "https://example.com/7faultyRope_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 22)
                    },
                    new Media
                    {
                        ID = 24,
                        Content = faultyPrint,
                        Description = "faulty print",
                        MimeType = "image/jpg",
                        Links = "https://example.com/8faultPrint_video",
                        Part = context.Parts.FirstOrDefault(p => p.ID == 23)
                    });
                context.SaveChanges();
            }

            // OPERATION: ONE FOR EA. NCR ( DATES MUST MAKE SENSE )

            if (!context.Operations.Any())
            {
                //REPRESENTS A FORM NOT A PERSON! THERE HAS TO BE ONE To ONE WITH NCR. 10 NCRS = 10 PURCHASING 
                context.Operations.AddRange(
                new Operation
                {
                    ID = 1,
                    Name = "James Jones",
                    OperationDate = DateTime.Parse("2010-01-01"),
                    OperationDecision = (OperationDecision)1,
                    OperationNotes = "Rework per engineering disposition",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 2,
                    Name = "Jane Little",
                    OperationDate = DateTime.Parse("2011-04-15"),
                    OperationDecision = (OperationDecision)1,
                    OperationNotes = "Replacement required",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 3,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2013-08-22"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "Local fabricator to repaint Haver Grey and we will bill Western Cast for the costs",
                    OperationCar = false,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 4,
                    Name = "Sandy Roof",
                    OperationDate = DateTime.Parse("2014-12-07"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "make new",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 5,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2015-06-30"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "Use as is",
                    OperationCar = false,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 6,
                    Name = "Sam Smith",
                    OperationDate = DateTime.Parse("2016-09-14"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "Repaint required",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 7,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2017-11-25"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 8,
                    Name = "Jame Scot",
                    OperationDate = DateTime.Parse("2018-03-09"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 9,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2019-05-18"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 10,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2020-08-02"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 11,
                    Name = "James Jones",
                    OperationDate = DateTime.Parse("2021-10-11"),
                    OperationDecision = (OperationDecision)4,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 12,
                    Name = "James Jones",
                    OperationDate = DateTime.Parse("2022-02-26"),
                    OperationDecision = (OperationDecision)1,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 13,
                    Name = "Jane Little",
                    OperationDate = DateTime.Parse("2022-06-17"),
                    OperationDecision = (OperationDecision)1,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 14,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2022-12-07"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 15,
                    Name = "Sandy Roof",
                    OperationDate = DateTime.Parse("2022-12-10"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 16,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2023-03-24"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 17,
                    Name = "Sam Smith",
                    OperationDate = DateTime.Parse("2023-07-09"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 18,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2023-10-20"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 19,
                    Name = "Jame Scot",
                    OperationDate = DateTime.Parse("2023-11-02"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 20,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2023-12-15"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 21,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2024-01-01"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 22,
                    Name = "James Jones",
                    OperationDate = DateTime.Parse("2024-01-10"),
                    OperationDecision = (OperationDecision)4,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 23,
                    Name = "Sam Smith",
                    OperationDate = DateTime.Parse("2024-01-15"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "Repaint required",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 24,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2024-01-25"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 25,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2024-02-02"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 26,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2024-02-08"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 27,
                    Name = "Sam Smith",
                    OperationDate = DateTime.Parse("2024-02-12"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 28,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2024-02-18"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 29,
                    Name = "Jame Scot",
                    OperationDate = DateTime.Parse("2024-02-21"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 30,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2024-02-29"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = true,
                },
                new Operation
                {
                    ID = 31,
                    Name = "Matt Turner",
                    OperationDate = DateTime.Parse("2024-03-01"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 32,
                    Name = "James Jones",
                    OperationDate = DateTime.Parse("2024-03-03"),
                    OperationDecision = (OperationDecision)4,
                    OperationNotes = "N/A",
                    OperationCar = false,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 33,
                    Name = "Sam Smith",
                    OperationDate = DateTime.Parse("2024-03-05"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "Repaint required",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 34,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2024-03-06"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                },
                new Operation
                {
                    ID = 35,
                    Name = "Alex Baxter",
                    OperationDate = DateTime.Parse("2024-03-08"),
                    OperationDecision = (OperationDecision)2,
                    OperationNotes = "N/A",
                    OperationCar = true,
                    OperationFollowUp = false,
                });

                context.SaveChanges();
            }

            // ENGINEERING: ONE FOR EA. NCR ( DATES MUST MAKE SENSE )

            if (!context.Engineerings.Any())
            {
                context.Engineerings.AddRange(
                new Engineering
                {
                    ID = 1,
                    CustomerNotify = false,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering suggested a change in the assembly process to improve efficiency",
                    RevisionOriginal = 12345,
                    RevisionUpdated = 12346,
                    RevisionDate = DateTime.Parse("2010-01-01"),
                    Name = "John Smith",
                    Date = DateTime.Parse("2010-01-01"),
                    EngineeringDisposition = 0
                },
                new Engineering
                {
                    ID = 2,
                    CustomerNotify = true,
                    DrawUpdate = true,
                    DispositionNotes = "Engineering instructed the fabrication team to use a higher-grade alloy for improved durability",
                    RevisionOriginal = 32434,
                    RevisionUpdated = 52123,
                    RevisionDate = DateTime.Parse("2011-04-15"),
                    Name = "James Brady",
                    Date = DateTime.Parse("2011-04-15"),
                    EngineeringDisposition = (EngineeringDisposition)1,
                },
                new Engineering
                {
                    ID = 3,
                    CustomerNotify = false,
                    DrawUpdate = true,
                    DispositionNotes = "Engineering revised the technical specifications to accommodate new performance requirements",
                    RevisionOriginal = 87645,
                    RevisionUpdated = 54632,
                    RevisionDate = DateTime.Parse("2013-08-22"),
                    Name = "Linda Johnson",
                    Date = DateTime.Parse("2013-08-22"),
                    EngineeringDisposition = (EngineeringDisposition)2,
                },
                new Engineering
                {
                    ID = 4,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering provided clarification on the tolerance requirements for precision machining",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2014-12-07"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2014-12-07"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 5,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering recommended a redesign of the structural support to enhance stability",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2015-06-30"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2025-06-30"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 6,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering advised increasing the thickness of the material to meet safety standards.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2016-09-14"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2016-09-14"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 7,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering proposed integrating a new feature to enhance product functionality.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2017-11-25"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2017-11-25"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 8,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "N/A",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2018-03-09"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2018-03-09"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 9,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering identified a potential flaw in the design and suggested a modification",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2019-05-18"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2019-05-18"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 10,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering conducted a feasibility study for implementing a cost-saving measure",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2020-08-02"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2020-08-02"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 11,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering insisted on creating a new way to solve this problem.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2021-10-11"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2021-10-11"),
                    EngineeringDisposition = (EngineeringDisposition)3,

                },
                new Engineering
                {
                    ID = 12,
                    CustomerNotify = false,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering suggested a change in the assembly process to improve efficiency",
                    RevisionOriginal = 12345,
                    RevisionUpdated = 12346,
                    RevisionDate = DateTime.Parse("2022-02-26"),
                    Name = "John Smith",
                    Date = DateTime.Parse("2022-02-26"),
                    EngineeringDisposition = 0
                },
                new Engineering
                {
                    ID = 13,
                    CustomerNotify = true,
                    DrawUpdate = true,
                    DispositionNotes = "Engineering instructed the fabrication team to use a higher-grade alloy for improved durability",
                    RevisionOriginal = 32434,
                    RevisionUpdated = 52123,
                    RevisionDate = DateTime.Parse("2022-06-17"),
                    Name = "James Brady",
                    Date = DateTime.Parse("2022-06-17"),
                    EngineeringDisposition = (EngineeringDisposition)1,
                },
                new Engineering
                {
                    ID = 14,
                    CustomerNotify = false,
                    DrawUpdate = true,
                    DispositionNotes = "Engineering revised the technical specifications to accommodate new performance requirements",
                    RevisionOriginal = 87645,
                    RevisionUpdated = 54632,
                    RevisionDate = DateTime.Parse("2022-12-07"),
                    Name = "Linda Johnson",
                    Date = DateTime.Parse("2022-12-07"),
                    EngineeringDisposition = (EngineeringDisposition)2,
                },
                new Engineering
                {
                    ID = 15,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering provided clarification on the tolerance requirements for precision machining",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2022-12-10"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2022-12-10"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 16,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering recommended a redesign of the structural support to enhance stability",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2023-03-24"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2023-03-24"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 17,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering advised increasing the thickness of the material to meet safety standards.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2023-07-09"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2023-07-09"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 18,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering proposed integrating a new feature to enhance product functionality.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2023-10-20"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2023-10-20"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 19,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "N/A",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2023-11-02"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2023-11-02"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 20,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering identified a potential flaw in the design and suggested a modification",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2023-12-15"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2023-12-15"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 21,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering conducted a feasibility study for implementing a cost-saving measure",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-01-01"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-01-01"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 22,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering insisted on creating a new way to solve this problem.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-01-10"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-01-10"),
                    EngineeringDisposition = (EngineeringDisposition)3,

                },
                new Engineering
                {
                    ID = 23,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering identified a potential flaw in the design and suggested a modification",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-01-15"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-01-15"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 24,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering conducted a feasibility study for implementing a cost-saving measure",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-01-25"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-01-25"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 25,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering insisted on creating a new way to solve this problem.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-02-02"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-02-02"),
                    EngineeringDisposition = (EngineeringDisposition)3,

                },
                new Engineering
                {
                    ID = 26,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering recommended a redesign of the structural support to enhance stability",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-02-08"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-02-08"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 27,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering advised increasing the thickness of the material to meet safety standards.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-02-12"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-02-12"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 28,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering proposed integrating a new feature to enhance product functionality.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-02-18"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-02-18"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 29,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "N/A",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-02-21"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-02-21"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 30,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering identified a potential flaw in the design and suggested a modification",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-02-29"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-02-29"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 31,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering conducted a feasibility study for implementing a cost-saving measure",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-03-01"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-03-01"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 32,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering insisted on creating a new way to solve this problem.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-03-03"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-03-03"),
                    EngineeringDisposition = (EngineeringDisposition)3,

                },
                new Engineering
                {
                    ID = 33,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering identified a potential flaw in the design and suggested a modification",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-03-05"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-03-05"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 34,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering conducted a feasibility study for implementing a cost-saving measure",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-03-06"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-03-06"),
                    EngineeringDisposition = (EngineeringDisposition)3,
                },
                new Engineering
                {
                    ID = 35,
                    CustomerNotify = true,
                    DrawUpdate = false,
                    DispositionNotes = "Engineering insisted on creating a new way to solve this problem.",
                    RevisionOriginal = 09854,
                    RevisionUpdated = 23465,
                    RevisionDate = DateTime.Parse("2024-03-08"),
                    Name = "Luke Miller",
                    Date = DateTime.Parse("2024-03-08"),
                    EngineeringDisposition = (EngineeringDisposition)3,

                });
                context.SaveChanges();
            }

            // PROCUREMENT NCRs 1- 23 needed bc they are complete

            if (!context.Procurements.Any())
            {
                context.Procurements.AddRange(
                    new Procurement
                    {
                        ID = 1,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2010-01-01"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                        //NCR = context.NCRs.FirstOrDefault(n => n.ID == 25) // Adjust this according to your NCR seeding
                    },
                    new Procurement
                    {
                        ID = 2,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2011-04-15"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                        //NCR = context.NCRs.FirstOrDefault(n => n.ID == 25), // Adjust this according to your NCR seeding
                    },
                    new Procurement
                    {
                        ID = 3,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2013-08-22"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 4,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2014-12-07"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 5,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2015-06-30"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 6,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2016-09-14"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 7,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2017-11-25"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 8,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2018-03-09"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                    },
                    new Procurement
                    {
                        ID = 9,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2019-05-18"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 10,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2020-08-02"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                    },
                    new Procurement
                    {
                        ID = 11,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2021-10-11"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 12,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2022-02-26"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 13,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2022-06-17"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                    },
                    new Procurement
                    {
                        ID = 14,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2022-12-07"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 15,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2022-12-10"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 16,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2023-03-24"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 17,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2023-07-09"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 18,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2023-10-20"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 19,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2023-11-02"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                    },
                    new Procurement
                    {
                        ID = 20,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2023-12-15"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 21,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2024-01-01"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                    },
                    new Procurement
                    {
                        ID = 22,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2024-01-10"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 23,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        ToReceiveDate = DateTime.Parse("2024-01-15"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 24,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2024-01-25"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 25,
                        ReturnRejected = false,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2024-02-02"),
                        SuppReturnCompletedSAP = false,
                        ExpectSuppCredit = false,
                        BillSupplier = true
                    },
                    new Procurement
                    {
                        ID = 26,
                        ReturnRejected = true,
                        RMANumber = 14245,
                        CarrierName = "Carrier B",
                        CarrierPhone = "320-456-7890",
                        AccountNumber = 421654321,
                        DisposeOnSite = true,
                        ToReceiveDate = DateTime.Parse("2024-02-08"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 27,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2024-02-12"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    },
                    new Procurement
                    {
                        ID = 28,
                        ReturnRejected = true,
                        RMANumber = 12345,
                        CarrierName = "Carrier A",
                        CarrierPhone = "123-456-7890",
                        AccountNumber = 987654321,
                        //DisposeOnSite = false, //THIS IS NULL IF RETURN REJECTED = TRUE
                        ToReceiveDate = DateTime.Parse("2024-02-18"),
                        SuppReturnCompletedSAP = true,
                        ExpectSuppCredit = true,
                        BillSupplier = false
                    });
                context.SaveChanges();
            }
            // Add more procurement instances as needed

            //context.Procurements.AddRange(procurements);
            //context.SaveChanges();


            // QUALITY INSPECTION: ONE FOR EA. NCR ( DATES MUST MAKE SENSE )

            if (!context.QualityInspections.Any())
            {
                context.QualityInspections.AddRange(
                    new QualityInspection
                    {
                        ID = 1,
                        Name = "Diego Fiery",
                        Date = DateTime.Parse("2010-01-01"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 2,
                        Name = "John Doe",
                        Date = DateTime.Parse("2011-04-15"),
                        QualityIdentify = (QualityIdentify)2,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 3,
                        Name = "Sam Jordan",
                        Date = DateTime.Parse("2013-08-22"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 4,
                        Name = "Gregy Frog",
                        Date = DateTime.Parse("2014-12-07"),
                        QualityIdentify = (QualityIdentify)2,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 5,
                        Name = "Pillow Man",
                        Date = DateTime.Parse("2015-06-30"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 6,
                        Name = "Jorge Jeez",
                        Date = DateTime.Parse("2016-09-14"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 7,
                        Name = "Hunt Con",
                        Date = DateTime.Parse("2017-11-25"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 8,
                        Name = "Rise Saint",
                        Date = DateTime.Parse("2018-03-09"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 9,
                        Name = "Sunday Smith",
                        Date = DateTime.Parse("2019-05-18"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 10,
                        Name = "Prin Char",
                        Date = DateTime.Parse("2020-08-02"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 11,
                        Name = "Lei Ter",
                        Date = DateTime.Parse("2021-10-11"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 12,
                        Name = "Diego Fiery",
                        Date = DateTime.Parse("2022-02-26"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 13,
                        Name = "John Doe",
                        Date = DateTime.Parse("2022-06-17"),
                        QualityIdentify = (QualityIdentify)2,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 14,
                        Name = "Sam Jordan",
                        Date = DateTime.Parse("2022-12-07"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 15,
                        Name = "Gregy Frog",
                        Date = DateTime.Parse("2022-12-10"),
                        QualityIdentify = (QualityIdentify)2,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 16,
                        Name = "Pillow Man",
                        Date = DateTime.Parse("2023-03-24"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 17,
                        Name = "Jorge Jeez",
                        Date = DateTime.Parse("2023-07-09"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 18,
                        Name = "Hunt Con",
                        Date = DateTime.Parse("2023-10-20"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 19,
                        Name = "Rise Saint",
                        Date = DateTime.Parse("2023-11-02"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 20,
                        Name = "Sunday Smith",
                        Date = DateTime.Parse("2023-12-15"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 21,
                        Name = "Prin Char",
                        Date = DateTime.Parse("2024-01-01"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 22,
                        Name = "Lei Ter",
                        Date = DateTime.Parse("2024-01-10"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 23,
                        Name = "Pillow Man",
                        Date = DateTime.Parse("2024-01-15"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    // FIRST NCR IN LIST //

                    new QualityInspection
                    {
                        ID = 24, // FIRST NCR IN LIST //
                        Name = "Jorge Jeez",
                        QualityIdentify = (QualityIdentify)0,
                        Date = DateTime.Parse("2024-01-25"),
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 25,
                        Name = "Rise Saint",
                        Date = DateTime.Parse("2024-02-02"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },

                    new QualityInspection
                    {
                        ID = 26,
                        Name = "Pillow Man",
                        Date = DateTime.Parse("2024-02-08"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 27,
                        Name = "Jorge Jeez",
                        Date = DateTime.Parse("2024-02-12"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 28,
                        Name = "Hunt Con",
                        Date = DateTime.Parse("2024-02-18"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 29,
                        Name = "Rise Saint",
                        Date = DateTime.Parse("2024-02-21"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 30,
                        Name = "Sunday Smith",
                        Date = DateTime.Parse("2024-02-29"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 31,
                        Name = "Pillow Man",
                        Date = DateTime.Parse("2024-03-01"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 32,
                        Name = "Jorge Jeez",
                        Date = DateTime.Parse("2024-03-03"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 33,
                        Name = "Hunt Con",
                        Date = DateTime.Parse("2024-03-05"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 34,
                        Name = "Rise Saint",
                        Date = DateTime.Parse("2024-03-06"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    },
                    new QualityInspection
                    {
                        ID = 35,
                        Name = "Sunday Smith",
                        Date = DateTime.Parse("2024-03-08"),
                        QualityIdentify = (QualityIdentify)1,
                        ItemMarked = true
                    });
                context.SaveChanges();
            }

            // LAST SECTION OF REPORT FOR QUALITY INSPECTION //

            if (!context.QualityInspectionFinals.Any())
            {
                context.QualityInspectionFinals.AddRange(
                    new QualityInspectionFinal
                    {
                        ID = 1,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2010-01-01"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2010-01-01")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 2,
                        ReInspected = true,
                        Department = "Department 2",
                        DepartmentDate = DateTime.Parse("2011-04-15"),
                        InspectorName = "Billy Bam",
                        InspectorDate = DateTime.Parse("2011-04-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 3,
                        ReInspected = true,
                        Department = "Department 3",
                        DepartmentDate = DateTime.Parse("2013-08-22"),
                        InspectorName = "April Apple",
                        InspectorDate = DateTime.Parse("2013-08-22")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 4,
                        ReInspected = true,
                        Department = "Department 4",
                        DepartmentDate = DateTime.Parse("2014-12-07"),
                        InspectorName = "Abigail Week",
                        InspectorDate = DateTime.Parse("2014-12-07")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 5,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2015-06-30"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2015-06-30")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 6,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2016-09-14"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2016-09-14")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 7,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2017-11-25"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2017-11-25")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 8,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2018-03-09"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2018-03-09")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 9,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2019-05-18"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2019-05-18")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 10,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2020-08-02"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2020-08-02")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 11,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2021-10-11"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2021-10-11")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 12,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2022-02-26"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2022-02-26")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 13,
                        ReInspected = true,
                        Department = "Department 2",
                        DepartmentDate = DateTime.Parse("2022-06-17"),
                        InspectorName = "Billy Bam",
                        InspectorDate = DateTime.Parse("2022-06-17")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 14,
                        ReInspected = true,
                        Department = "Department 3",
                        DepartmentDate = DateTime.Parse("2022-12-07"),
                        InspectorName = "April Apple",
                        InspectorDate = DateTime.Parse("2022-12-07")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 15,
                        ReInspected = true,
                        Department = "Department 4",
                        DepartmentDate = DateTime.Parse("2022-12-10"),
                        InspectorName = "Abigail Week",
                        InspectorDate = DateTime.Parse("2022-12-10")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 16,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2023-03-24"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2023-03-24")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 17,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2023-07-09"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2023-07-09")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 18,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2023-10-20"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2023-10-20")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 19,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2023-11-02"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2023-11-02")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 20,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2023-12-15"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2023-12-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 21,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2024-01-01"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2024-01-01")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 22,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2024-01-10"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2024-01-10")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 23,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "Johnny Jam",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 24,
                        ReInspected = true,
                        Department = "Department 2",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "James Jam",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 25,
                        ReInspected = true,
                        Department = "Department 3",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "Rogan City",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 26,
                        ReInspected = true,
                        Department = "Department 4",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "Clark Man",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 27,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "Cark San",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 28,
                        ReInspected = true,
                        Department = "Department 1",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "Tesco Lad",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    },
                    new QualityInspectionFinal
                    {
                        ID = 29,
                        ReInspected = true,
                        Department = "Department 2",
                        DepartmentDate = DateTime.Parse("2024-01-15"),
                        InspectorName = "George Gee",
                        InspectorDate = DateTime.Parse("2024-01-15")
                    }

                    // FIRST NCR IN LIST //

                    //new QualityInspectionFinal
                    //{
                    //    ID = 24, 
                    //    ReInspected = true, 
                    //    Department = "Department 2",
                    //    DepartmentDate = DateTime.Parse("2022-06-17"),
                    //    InspectorName = "Billy Bam",
                    //    InspectorDate = DateTime.Parse("2022-06-17"),
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 25,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},

                    //new QualityInspectionFinal
                    //{
                    //    ID = 26,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 27,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 28,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 29,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 30,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 31,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 32,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 33,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 34,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    //},
                    //new QualityInspectionFinal
                    //{
                    //    ID = 35,
                    //    ReInspected = true,
                    //    Department = "Department 1",
                    //    DepartmentDate = DateTime.Parse("2022-02-26"),
                    //    InspectorName = "Johnny Jam",
                    //    InspectorDate = DateTime.Parse("2022-02-26")
                    );
                context.SaveChanges();
            }

            // ACTUAL NCRS: MAKE SURE DATES ARE CORRECT AND MAKE SENSE

            if (!context.NCRs.Any())
            {
                context.NCRs.AddRange(
                    new NCR //Ok so NCR 1-7 were assigned the same Part ID's as NCR 24 to 29.. 
                    {       //So this WAS 1, but to not have to change 20+ Id's - going to change these first 7.
                        ID = 1, //will assign these 24
                        NCR_Date = DateTime.Parse("2017-01-01"),
                        IsVoid = true,
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,       //NCR Stage can be changed to match the data 
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 1),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 24),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 1),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 1),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 1),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 1),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 1)
                    },
                    new NCR
                    {
                        ID = 2,
                        NCR_Date = DateTime.Parse("2011-04-15"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 25),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 2),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 2),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 2),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 4),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 2)
                    },
                    new NCR
                    {
                        ID = 3,
                        NCR_Date = DateTime.Parse("2013-08-22"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        NewNCRID = 8,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 26),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 3),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 3),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 3),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 3),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 3)
                    },
                    new NCR
                    {
                        ID = 4,
                        NCR_Date = DateTime.Parse("2014-12-07"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 3),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 27),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 4),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 4),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 4),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 4),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 4)
                    },
                    new NCR
                    {
                        ID = 5,
                        NCR_Date = DateTime.Parse("2015-06-30"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 28),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 5),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 5),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 5),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 5),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 5)
                    },
                    new NCR
                    {
                        ID = 6,
                        NCR_Date = DateTime.Parse("2016-09-14"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 29),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 6),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 6),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 6),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 6),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 6)

                    },
                    new NCR
                    {
                        ID = 7,
                        NCR_Date = DateTime.Parse("2017-11-25"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 30),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 7),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 7),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 7),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 7),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 7)
                    },
                    new NCR
                    {
                        ID = 8,
                        NCR_Date = DateTime.Parse("2018-03-09"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 8),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 8),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 8),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 8),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 8),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 8)
                    },
                    new NCR
                    {
                        ID = 9,
                        NCR_Date = DateTime.Parse("2019-05-18"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5, //Completed
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 9),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 9),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 9),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 9),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 9),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 9)
                    },
                    new NCR
                    {
                        ID = 10,
                        NCR_Date = DateTime.Parse("2020-08-02"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 10),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 10),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 10),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 10),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 10),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 10)
                    },
                    new NCR
                    {
                        ID = 11,

                        NCR_Date = DateTime.Parse("2021-10-11"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 11),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 11),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 11),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 11),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 11),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 11)
                    },
                    new NCR
                    {
                        ID = 12,
                        NCR_Date = DateTime.Parse("2022-02-26"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 1),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 12),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 12),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 12),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 12),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 12),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 12)
                    },
                    new NCR
                    {
                        ID = 13,
                        NCR_Date = DateTime.Parse("2022-06-17"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 13),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 13),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 13),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 13),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 13),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 13)
                    },
                    new NCR
                    {
                        ID = 14,
                        NCR_Date = DateTime.Parse("2022-12-07"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 14),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 14),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 14),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 14),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 14), //Re-inspected Acceptable = No
                        NewNCRID = 15 // New NCR is the next one generated
                    },
                    new NCR
                    {
                        ID = 15,
                        NCR_Date = DateTime.Parse("2022-12-10"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 3),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 15),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 15),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 15),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 15),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 15),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 15)
                    },
                    new NCR
                    {
                        ID = 16,
                        NCR_Date = DateTime.Parse("2023-07-09"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 16),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 16),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 16),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 16),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 16),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 16)
                    },
                    new NCR
                    {
                        ID = 17,
                        NCR_Date = DateTime.Parse("2023-07-09"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 17),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 17),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 17),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 17),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 17),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 17)

                    },
                    new NCR
                    {
                        ID = 18,
                        NCR_Date = DateTime.Parse("2023-10-20"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 18),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 18),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 18),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 18),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 18),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 18)
                    },
                    new NCR
                    {
                        ID = 19,
                        NCR_Date = DateTime.Parse("2023-11-02"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 19),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 19),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 19),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 19),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 19),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 19)
                    },
                    new NCR
                    {
                        ID = 20,
                        NCR_Date = DateTime.Parse("2023-12-15"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 20),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 20),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 20),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 20),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 20),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 20)
                    },
                    new NCR
                    {
                        ID = 21,
                        NCR_Date = DateTime.Parse("2024-01-01"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 21),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 21),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 21),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 21),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 21),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 21)
                    },
                    new NCR
                    {
                        ID = 22,

                        NCR_Date = DateTime.Parse("2024-01-10"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5,
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 22),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 22),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 22),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 22),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 22),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 22)
                    },
                    new NCR
                    {
                        ID = 23,

                        NCR_Date = DateTime.Parse("2024-01-15"),
                        NCR_Status = false,
                        NCR_Stage = (NCRStage)5, // Complete
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 23),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 23),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 23),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 23),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 23),
                        QualityInspectionFinal = context.QualityInspectionFinals.FirstOrDefault(p => p.ID == 23)
                    },

                    new NCR
                    {
                        ID = 24,

                        NCR_Date = DateTime.Parse("2024-01-25"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)4, //QualityRepFinal
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 1),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 24),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 24),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 24),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 24),
                    },
                    new NCR
                    {
                        ID = 25,

                        NCR_Date = DateTime.Parse("2024-02-02"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)4, //QualityRep
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 2),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 25),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 25),
                        Procurement = context.Procurements.FirstOrDefault(p => p.ID == 25), //TESTING PROCUREMENT
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 25),

                    },
                    new NCR
                    {
                        ID = 26,

                        NCR_Date = DateTime.Parse("2024-02-08"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)3, //Procurement
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 3),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 26),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 26),
                        //Procurement = context.Procurements.FirstOrDefault(p => p.ID == 26),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 26)
                    },
                    new NCR
                    {
                        ID = 27,

                        NCR_Date = DateTime.Parse("2024-02-12"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)3, //Procurement
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 4),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 27),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 27),
                        //Procurement = context.Procurements.FirstOrDefault(p => p.ID == 27),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 27)
                    },
                    new NCR
                    {
                        ID = 28,

                        NCR_Date = DateTime.Parse("2024-02-18"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)3, //Procurement
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 5),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 28),
                        Operation = context.Operations.FirstOrDefault(p => p.ID == 28),
                        //Procurement = context.Procurements.FirstOrDefault(p => p.ID == 28),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 28)
                    },
                    new NCR
                    {
                        ID = 29,

                        NCR_Date = DateTime.Parse("2024-02-21"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)2, //Operations
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 5),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 6),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 29),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 29),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 29)
                    },
                    new NCR
                    {
                        ID = 30,

                        NCR_Date = DateTime.Parse("2024-02-29"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)2, //Operations
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 7),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 30),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 30),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 30)
                    },
                    new NCR
                    {
                        ID = 31,

                        NCR_Date = DateTime.Parse("2024-03-01"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)2, //Operations
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 31),
                        Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 31),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 31),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 31)
                    },
                    new NCR
                    {
                        ID = 32,

                        NCR_Date = DateTime.Parse("2024-03-03"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)1, //Engineering
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 7),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 32),
                        //Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 32),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 32),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 32)
                    },
                    new NCR
                    {
                        ID = 33,

                        NCR_Date = DateTime.Parse("2024-03-05"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)1, //Engineering
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 6),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 33),
                        //Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 33),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 33),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 33)
                    },
                    new NCR
                    {
                        ID = 34,

                        NCR_Date = DateTime.Parse("2024-03-06"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)1,  // Engineering Stage
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 4),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 34),
                        //Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 34),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 34),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 34)
                    },
                    new NCR
                    {
                        ID = 35,

                        NCR_Date = DateTime.Parse("2024-03-08"),
                        NCR_Status = true,
                        NCR_Stage = (NCRStage)1, // Engineering Stage
                        Supplier = context.Suppliers.FirstOrDefault(c => c.ID == 2),
                        Part = context.Parts.FirstOrDefault(p => p.ID == 35),
                        //Engineering = context.Engineerings.FirstOrDefault(p => p.ID == 35),
                        //Operation = context.Operations.FirstOrDefault(p => p.ID == 35),
                        QualityInspection = context.QualityInspections.FirstOrDefault(p => p.ID == 35)
                    });
                context.SaveChanges();
            }

            // CAR

            if (!context.CARs.Any())
            {
                var cars = new List<CAR>
                    {                                   //some operations dont have car or follow up raised, so do not assign them with an operation object here
                        new CAR {ID = 1, Date = DateTime.Parse("2010-01-01"), CARNumber = 12345, Operation = context.Operations.FirstOrDefault(p => p.ID == 1) },
                        new CAR {ID = 2, Date = DateTime.Parse("2011-04-15"), CARNumber = 98765, Operation = context.Operations.FirstOrDefault(p => p.ID == 2) },
                        new CAR {ID = 3, Date = DateTime.Parse("2013-08-22"), CARNumber = 56748, Operation = context.Operations.FirstOrDefault(p => p.ID == 3) },
                        new CAR {ID = 4, Date = DateTime.Parse("2014-12-07"), CARNumber = 84379, Operation = context.Operations.FirstOrDefault(p => p.ID == 4) },
                        new CAR {ID = 5, Date = DateTime.Parse("2024-02-15"), CARNumber = 93842, Operation = context.Operations.FirstOrDefault(p =>p.ID == 24) },  //this means the first 4 records do have car / follow up types
                        new CAR {ID = 6, Date = DateTime.Parse("2023-09-14"), CARNumber = 42981, Operation = context.Operations.FirstOrDefault(p =>p.ID == 25) },  //meaning the boolean values in operation
                        new CAR {ID = 7, Date = DateTime.Parse("2024-1-23"), CARNumber = 29013, Operation = context.Operations.FirstOrDefault(p =>p.ID == 26) },  //for these first 4, should be set to TRUE.
                        new CAR {ID = 8, Date = DateTime.Parse("2024-03-01"), CARNumber = 90842, Operation = context.Operations.FirstOrDefault(p =>p.ID == 27)},
                        new CAR {ID = 9, Date = DateTime.Parse("2019-05-18"), CARNumber = 32491},
                        new CAR {ID = 10, Date = DateTime.Parse("2020-08-02"), CARNumber = 31904}
                    };
                context.CARs.AddRange(cars);
                context.SaveChanges();
            }

            // FOLLOW UP

            if (!context.FollowUps.Any())
            {
                context.FollowUps.AddRange(
                new FollowUp
                {
                    ID = 1,
                    FollowUpDate = DateTime.Parse("2010-01-01"),
                    FollowUpType = "Phone Call",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 1)
                },
                new FollowUp
                {
                    ID = 2,
                    FollowUpDate = DateTime.Parse("2011-04-15"),
                    FollowUpType = "Email",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 2)
                },
                new FollowUp
                {
                    ID = 3,
                    FollowUpDate = DateTime.Parse("2013-08-22"),
                    FollowUpType = "Meeting",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 3)
                },
                new FollowUp
                {
                    ID = 4,
                    FollowUpDate = DateTime.Parse("2014-12-07"),
                    FollowUpType = "None",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 4) //Since Some Operations Will Have No Follow Up, Change Seed Data to Reflect that,
                },
                new FollowUp
                {
                    ID = 5,
                    FollowUpDate = DateTime.Parse("2024-03-09"),
                    FollowUpType = "Consultation",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 24)
                },
                new FollowUp
                {
                    ID = 6,
                    FollowUpDate = DateTime.Parse("2024-01-12"),
                    FollowUpType = "Group Meeting",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 25)
                },
                new FollowUp
                {
                    ID = 7,
                    FollowUpDate = DateTime.Parse("2024-02-02"),
                    FollowUpType = "Counselling",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 26)
                },
                new FollowUp
                {
                    ID = 8,
                    FollowUpDate = DateTime.Parse("2024-03-23"),
                    FollowUpType = "Meeting",
                    Operation = context.Operations.FirstOrDefault(p => p.ID == 27)
                });                                                               //So in operations if follow up = false, then that record should NOT have this an operations = firstordefault..  Same
                context.SaveChanges();                                          //same with the Car.
            }

            // DEFECT LIST

            //if (!context.DefectLists.Any())
            //{
            //    context.DefectLists.AddRange(

            //        new DefectList
            //        {
            //            DefectID = context.Defects.FirstOrDefault(d => d.Name == "Design Error (Drawing)").ID,
            //            PartID = context.Parts.FirstOrDefault(p => p.Name == "Wheels").ID
            //        },
            //        //new DefectList { DefectID = 1, PartID = 1 },
            //        new DefectList { DefectID = 2, PartID = 2 },
            //        new DefectList { DefectID = 3, PartID = 3 },
            //        new DefectList { DefectID = 4, PartID = 4 },
            //        new DefectList { DefectID = 5, PartID = 5 },
            //        new DefectList { DefectID = 6, PartID = 6 },
            //        new DefectList { DefectID = 7, PartID = 7 },
            //        new DefectList { DefectID = 8, PartID = 8 },
            //        new DefectList { DefectID = 9, PartID = 9 },
            //        new DefectList { DefectID = 10, PartID = 10 },
            //        new DefectList { DefectID = 11, PartID = 11 },
            //        new DefectList { DefectID = 12, PartID = 12 },
            //        new DefectList { DefectID = 13, PartID = 13 },
            //        new DefectList { DefectID = 14, PartID = 14 },
            //        new DefectList { DefectID = 15, PartID = 15 },
            //        new DefectList { DefectID = 16, PartID = 16 },
            //        new DefectList { DefectID = 17, PartID = 17 },
            //        new DefectList { DefectID = 18, PartID = 18 },
            //        new DefectList { DefectID = 19, PartID = 19 },
            //        new DefectList { DefectID = 20, PartID = 20 },
            //        new DefectList { DefectID = 21, PartID = 21 },
            //        new DefectList { DefectID = 22, PartID = 22 },
            //        new DefectList { DefectID = 23, PartID = 23 },
            //        new DefectList { DefectID = 24, PartID = 24 },
            //        new DefectList { DefectID = 23, PartID = 25 },
            //        new DefectList { DefectID = 23, PartID = 26 },
            //        new DefectList { DefectID = 11, PartID = 27 },
            //        new DefectList { DefectID = 11, PartID = 28 },
            //        new DefectList { DefectID = 11, PartID = 29 },
            //        new DefectList { DefectID = 11, PartID = 30 },
            //        new DefectList { DefectID = 11, PartID = 31 },
            //        new DefectList { DefectID = 11, PartID = 32 },
            //        new DefectList { DefectID = 11, PartID = 33 },
            //        new DefectList { DefectID = 11, PartID = 34 },
            //        new DefectList { DefectID = 11, PartID = 35 }
            //    );

            //    context.SaveChanges();
            //}


        }
    }
}