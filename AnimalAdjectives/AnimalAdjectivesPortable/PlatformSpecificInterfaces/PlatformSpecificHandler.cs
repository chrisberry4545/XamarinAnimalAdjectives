using System;
namespace AnimalAdjectivesPortable.PlatformSpecificInterfaces
{
	public class PlatformSpecificHandler
	{

		public IStorageInterface StorageInterface{ get; set; }
		public IViewHandler ViewHandler { get; set; }
		public IToastManager ToastManager{ get; set; }
		public IFileReader FileReader{get;set;}
	}
}

