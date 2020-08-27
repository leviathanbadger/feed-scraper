rm -f projects.tar
find . \( -name '*.csproj' -o -name '*.sln' -o -name 'nuget.config' \) -print0 | tar -cvf projects.tar --null -T -
