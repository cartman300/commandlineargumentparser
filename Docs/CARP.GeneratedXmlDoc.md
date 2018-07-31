# CARP #

#### Property ArgumentParser.Suffix

 Returns tokens after last empty '--' 



---
#### Property ArgumentParser.SuffixString

 Returns string after last empty '--' 



---
#### Property ArgumentParser.All

 Get all argument names and values passed to the program 



---
#### Property ArgumentParser.ExecutablePath

 Get exe path from command line 



---
#### Property ArgumentParser.CommandLine

 Get raw command line without the exe path 



---
#### Method ArgumentParser.Get(System.String)

 Get defined values as string array for argument 

|Name | Description |
|-----|------|
|Name: |Name of the argument|
**Returns**: Value array



---
#### Method ArgumentParser.Get``1(System.String)

 Get defined values as array for argument parsed to type T 

|Name | Description |
|-----|------|
|T: |Return type, has to have either a constructor that takes a string or a static Parse method|
|Name | Description |
|-----|------|
|Name: |Name of the argument|
**Returns**: Value array



---
#### Method ArgumentParser.GetSingle(System.String)

 Get last defined value for argument as string 

|Name | Description |
|-----|------|
|Name: |Name of the argument|
**Returns**: Value



---
#### Method ArgumentParser.GetSingle``1(System.String)

 Get last defined value for argument parsed to type T 

|Name | Description |
|-----|------|
|T: |Return type, has to have either a constructor that takes a string or a static Parse method|
|Name | Description |
|-----|------|
|Name: |Name of the argument|
**Returns**: Value



---
#### Method ArgumentParser.Defined(System.String)

 Check if argument was defined 

|Name | Description |
|-----|------|
|Name: |Name of argument|
**Returns**: True when defined, False when not defined



---


