# MapWinForms
Winforms application demonstrating mapping with MapWinGIS v 4.9.6.1. This was tested with MapWinGIS version 5.2.2 but not all functionality works

This is an excerpt of an application that was funded by a fisheries technical cooperation project funded by the generous people of the United States. The parts that were not included were data entry forms for encoding fisheries landings. 


Although the user interface is reduced to a bare minimum, all the mapping functionality from the original application are intact.

These are what this app demonstrates
1. Add a shapefile or a georereferenced layer to a map
2. With a TOC or table of content, rearrange map layers, remove a layer, show or hide a map layer, and setup layer symbology
3. Shapefile layer attributes can be viewed in a table. 

There will be functionality that I will add in the future

### Notes on Office2007ColorPicker
There is a project named Owf.Controls.Office2007ColorPicker that is embedded in this solution. You need to build this project to build Office2007ColorPicker.dll. Afterwards, just reference this dll in MapWinForms project.
