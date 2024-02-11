using System.Windows.Forms;
using WinFormsAppPLMUral;

namespace TestProjectWinFormsAppPLMUral
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateAssemblyAndUpdateAssembly()
        {
            using (var applicationContext = new WinFormsAppPLMUral.ApplicationContext(true))
            {
                
            }
            var mainViewModel = new MainViewModel();
            var id1 = mainViewModel.CreateAssembly("Деталь №1",null);
            var id2 = mainViewModel.CreateAssembly("Деталь №2", null);
            var assembly1 = mainViewModel.GetAssemblyUnitById(id1);
            assembly1.Details.Add(new WinFormsAppPLMUral.Models.RelationAseemblyToAssembly()
            {
                DetailId = id2,              
                Count = 33
            });
            mainViewModel.UpdateAssembly(assembly1);
            var updatedAssembly1= mainViewModel.GetAssemblyUnitById(id1);
            Assert.AreEqual(2, updatedAssembly1.Details[0].DetailId);
        }

        [Test]
        public void TestExportAndImport()
        {
            using (var applicationContext = new WinFormsAppPLMUral.ApplicationContext(true))
            {

            }
            var mainViewModel = new MainViewModel();
            var id1 = mainViewModel.CreateAssembly("Деталь №1", null);
            var id2 = mainViewModel.CreateAssembly("Деталь №2", null);
            var assembly1 = mainViewModel.GetAssemblyUnitById(id1);
            assembly1.Details.Add(new WinFormsAppPLMUral.Models.RelationAseemblyToAssembly()
            {
                DetailId = id2,
                Count = 33
            });
            mainViewModel.UpdateAssembly(assembly1);
            File.Delete(Environment.CurrentDirectory+"\\5.xlsx");
            mainViewModel.Export(Environment.CurrentDirectory + "\\5.xlsx");
            mainViewModel.Import(Environment.CurrentDirectory + "\\5.xlsx");
            var updatedAssembly1 = mainViewModel.GetAssemblyUnitById(id1);
            Assert.AreEqual(2, updatedAssembly1.Details[0].DetailId);
        }
    }
}