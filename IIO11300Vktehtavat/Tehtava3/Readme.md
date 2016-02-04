Missing MainWindow.xaml file when syncing.
Added here all code:

Window x:Class="JAMK.IT.IIO11300.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:JAMK.IT.IIO11300"
        mc:Ignorable="d"
        Title="WinLotto" Height="400" Width="520">

    <Grid>
        <StackPanel Orientation="Vertical">
            <StackPanel Orientation="Horizontal">
                <TextBlock x:Name="tbChooseTheGame" FontSize="12" Text="Choose the game" Height="20" Margin="10,10,10,0" />
                <ComboBox x:Name="comboSelectGame"  VerticalAlignment="Top" Loaded="comboSelectGame_Loaded" SelectedIndex="0" Margin="10,10,10,0" Width="100" />
                <TextBlock x:Name="tbCorrectRow" FontSize="12" Text="Check numbers (space between numbers):" Height="20" Margin="25,10,10,0" />
            </StackPanel>
            <StackPanel Orientation="Horizontal">
                <TextBlock x:Name="tbNumberOfDraws" FontSize="12" Text="Number of drawns" Height="20" Margin="10, 10, 10, 0"/>
                <TextBox x:Name="txtNumberOfDrawns" Text="1" HorizontalAlignment="Left" Width="42" Margin="10,3,10,3" />
                <TextBox x:Name="txtCorrectRow" Text="" HorizontalAlignment="Left" Width="230" Margin="80,3,10,3" />
            </StackPanel>
            <StackPanel Orientation="Horizontal">
                <Button x:Name="btnDraw" Content="Draw" Click="btnDraw_Click" Margin="10,0,0,0" Width="75"/>
                <Button x:Name="btnClear" Content="Clear" Click="btnClear_Click" Margin="10,0,0,0" Width="75"/>
                <Button x:Name="btnCheck" Content="Check" Click="btnCheckRows_Click" Margin="90,0,0,0" Width="75"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal">
                <TextBlock x:Name="tbRandomlyDrawnNumbers" FontSize="12" HorizontalAlignment="Left" Text="Randomly drawn numbers:" Height="20" Margin="10, 10, 10, 0" Width="142"/>
                <TextBlock x:Name="tbCorrectNumberMatches" FontSize="12" HorizontalAlignment="Left" Text="Correct numbers/row:" Height="20" Margin="100, 10, 10, 0" Width="142"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal">
                <TextBox x:Name="txtRandomlyDrawnNumbers" Text="" Height="190" Margin="10,0,0,0" Width="240" />
                <TextBox x:Name="txtMatchedNumbers" Text="" Height="190" Margin="10,0,0,0" Width="240" />
            </StackPanel>
            <StackPanel Orientation="Horizontal">
                <Button x:Name="btnSave" Content="Save" Click="btnSave_Click" Margin="10,10,0,0" Width="75"/>
                <Button x:Name="btnClose" Content="Close" Click="btnClose_Click" Margin="330,10,0,0" Width="75"/>
            </StackPanel>
        </StackPanel>
    </Grid>
</Window>
