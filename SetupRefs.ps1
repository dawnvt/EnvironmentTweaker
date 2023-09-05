# Get the install location of Beat Saber
$Path = Get-ItemPropertyValue -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 620980" -Name "InstallLocation"

# Create a symbolic link to the Beat Saber folder
New-Item -ItemType Junction -Path "Refs" -Target "$Path"