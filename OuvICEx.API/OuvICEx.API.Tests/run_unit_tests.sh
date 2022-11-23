#!/bin/sh
dotnet test --filter FullyQualifiedName~Unit --collect:"XPlat Code Coverage"
xmlpath=$(find . -name coverage.cobertura.xml)
reportgenerator -reports:"${xmlpath}" -targetdir:"unittest_coverage_report" -reporttypes:Html
rm -rf TestResults