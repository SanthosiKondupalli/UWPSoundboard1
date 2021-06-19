using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundboard1.Model
{
    public enum SoundCategory
    {
        Animals,
        Cartoons,
        Taunts,
        Warnings
    }
    public class Sound
    {
        public String Name{get; set;}
        public SoundCategory CategoryName { get; set;}
        public String ImageLink { get; set; }
        public String SoundLink { get; set; }
        public Sound(String name,SoundCategory category)
        {
            Name = name;
            CategoryName = category;
            SoundLink = $"/Assets/Audio/{category}/{name}.wav";
             ImageLink= $"/Assets/Images/{category}/{name}.png";

        }
    }

}
