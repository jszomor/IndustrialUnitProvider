using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class IntroductionViewModel
  {
    //private string[] _mainIntroduction;

    public string[] MainIntroduction
    {
      get { return ReadMainIntroduction(); }
      //set { _mainIntroduction = value; }
    }


    public string[] ReadMainIntroduction()
    {

      string fileName = "Introduction.txt";
      string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
      string docsFolder = Path.Combine(currentDirectory, "docs");
      string[] files = Directory.GetFiles(docsFolder, fileName);

      //FileStream fileStream = new();


      //StreamReader streamReader = new();

      return files;
    }


    public IntroductionViewModel()
    {

    }
  }
}
