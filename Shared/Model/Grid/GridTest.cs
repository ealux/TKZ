using TKZ.Shared.Model;

namespace TKZ.Shared
{
    public partial class Grid
    {
        /// <summary>
        /// Test grid with out ground.
        /// Consist random parametrs.
        /// </summary>
        private void createTestGrid()
        {
            Bus b1 = new Bus(100, "1");
            Bus b2 = new Bus(100, "2");
            Bus b3 = new Bus(100, "3");
            Bus b4 = new Bus(100, "4");
            Bus b5 = new Bus(100, "5");
            Bus b6 = new Bus(100, "6");
            Bus b7 = new Bus(100, "7");
            Bus b8 = new Bus(100, "8");
            Bus b9 = new Bus(100, "9");
            Bus b10 = new Bus(100, "10");

            this.Buses.Add(b1.Id, b1);
            this.Buses.Add(b2.Id, b2);
            this.Buses.Add(b3.Id, b3);
            this.Buses.Add(b4.Id, b4);
            this.Buses.Add(b5.Id, b5);
            this.Buses.Add(b6.Id, b6);
            this.Buses.Add(b7.Id, b7);
            this.Buses.Add(b8.Id, b8);
            this.Buses.Add(b9.Id, b9);
            this.Buses.Add(b10.Id, b10);

            Branch br1 = new Branch(b1.Id, b2.Id, "1-2", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br2 = new Branch(b3.Id, b1.Id, "3-1", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br3 = new Branch(b1.Id, b4.Id, "1-4", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br4 = new Branch(b2.Id, b5.Id, "2-5", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br5 = new Branch(b3.Id, b6.Id, "3-6", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br6 = new Branch(b3.Id, b7.Id, "3-7", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br7 = new Branch(b4.Id, b8.Id, "4-8", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br8 = new Branch(b5.Id, b9.Id, "5-9", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br9 = new Branch(b6.Id, b10.Id, "6-10", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br10 = new Branch(b7.Id, b8.Id, "7-8", 1, 2, 3, 4, 5, 6, 7, false, false);
            Branch br11 = new Branch(b2.Id, b10.Id, "2-10", 1, 2, 3, 4, 5, 6, 7, false, true);
            Branch br12 = new Branch(b10.Id, b8.Id, "10-8", 1, 2, 3, 4, 5, 6, 7, true, false);

            this.Branches.Add(br1.Id, br1);
            this.Branches.Add(br2.Id, br2);
            this.Branches.Add(br3.Id, br3);
            this.Branches.Add(br4.Id, br4);
            this.Branches.Add(br5.Id, br5);
            this.Branches.Add(br6.Id, br6);
            this.Branches.Add(br7.Id, br7);
            this.Branches.Add(br8.Id, br8);
            this.Branches.Add(br9.Id, br9);
            this.Branches.Add(br10.Id, br10);
            this.Branches.Add(br11.Id, br11);
            this.Branches.Add(br12.Id, br12);            

            Mutual m1 = new Mutual(br1.Id, br2.Id, 1, 2);
            Mutual m2 = new Mutual(br3.Id, br4.Id, 13, 2);

            this.Mutuals.Add(m1.Id, m1);
            this.Mutuals.Add(m2.Id, m2);

            Equip e1 = new Equip(b1.Id, 1, 1, "Генератор 1-1", 1, 30);
            Equip e2 = new Equip(b1.Id, 1, 1, "Генератор 1-2", 1, 30);
            Equip e3 = new Equip(b2.Id, 1, 1, "Генератор 2-1", 1, 30);
            Equip e4 = new Equip(b2.Id, 1, 1, "Генератор 2-2", 1, 30);

            this.Equipment.Add(e1.Id, e1);
            this.Equipment.Add(e2.Id, e2);
            this.Equipment.Add(e3.Id, e3);
            this.Equipment.Add(e4.Id, e4);
        }
    }
}
