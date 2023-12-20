# Character-Editor
This is a font editor for 8-bit style computers. 

Fonts are stored in a 1 byte per row format. Each row is 8 pixels wide, and 
each bit in the row represents one pixel. The high bit is the left pixel, and 
the low bit is the right pixel.

The editor can handle character cell sizes from 8 to 16 bytes per cell. 

## Building

This requires a recent version of MS Visual Studio. The Community edition will work just fine. You can get it from https://www.visualstudio.com

## Use
Before loading a character set, first pull down the combo box at the top (which probably says "8") and change that to the size of the 
set you want to load. For an 8x8 set, set that to 8. For an 8x12 or 8x16 set, change the vlaue to 12 or 16. If you have this set wrong, 
the data loaded from your BIN file won't line up properly. 

Click a character to edit it over on the right panel. 

Do you want to help line up your other characters? To the right of the character editor panel is a black column. 
Click that to turn on guides in taht row of the character cell editor. Use this to line up baselines, descenders, whatever. 

## License
License is GPL3. Copyright is Tom P. Wilson. 

I am developing a custom 8x8 font in conjunction with this product. The font files are free for any use, with
attribution. Please link back to this GitHub repository. I would love to see everyone in the retro community
use the hybrid PET-ASCII font as their official font for 8 and 16 bit retro computers.

I'd love a heads-up when forking this or using it in your project. 
wilsontp (at) gmail.com

