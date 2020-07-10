if ($args[0] -eq $null)
{
    Write-host "Specify migration name"
}
else
{
    dotnet ef --startup-project ../TT.Diary.WebAPI/ migrations add $args[0]
    dotnet ef --startup-project ../TT.Diary.WebAPI/ database update
}