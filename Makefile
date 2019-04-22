test:
	dotnet test Examples/Calculator.Tests/Calculator.Tests.csproj

format:
	cd ./Redux && dotnet format
	cd ./Examples/Calculator.Tests && dotnet format
	cd ./Examples/Calculator && dotnet format
