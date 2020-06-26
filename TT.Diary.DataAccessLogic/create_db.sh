#!/bin/bash
if [ -n "$1" ]
then
    dotnet ef --startup-project ../TT.Diary.WebAPI/ migrations add $1
    dotnet ef --startup-project ../TT.Diary.WebAPI/ database update
else
    echo "Specify migration name"
fi