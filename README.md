# Character-Editor
This is a font editor for 8-bit style computers. 

Fonts are stored in a 1 byte per row format. Each row is 8 pixels wide, and 
each bit in the row represents one pixel. The high bit is the left pixel, and 
the low bit is the right pixel.

The editor can handle character cell sizes from 8 to 16 bytes per cell. 

## Use
To load a character set, first pull down the combo box at the top (which probably says "8") and change that to the size of the set you want to load. For an 8x8 set, set that to 8. For an 8x12 or 8x16 set, change the vlaue to 12 or 16. 

Click a character to edit it over on the right panel. 

Do you want to help line up your other characters? To the right of the character editor panel is a black column. 
Click that to turn on guides in taht row of the character cell editor. Use this to line up baselines, descenders, whatever. 

## License
License is GPL3. Copyright is Tom P. Wilson. 

I'd love a heads-up when forking this or using it in your project. 
wilsontp (at) gmail.com

