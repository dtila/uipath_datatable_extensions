# UiPath DataTable extensions


Manipulate DataTable operations easily. No activities, just using functions.

Build status: ![Current Build status](https://github.com/dtila/uipath_datatable_extensions/workflows/CI/badge.svg?branch=main)

Currently the following operations are supported:
- DataTable split
- DataTable batch size split


## How to use it
1. Install the package from [UiPath Go](https://marketplace.uipath.com/listings/datatable-extensions)
2. Call the ``Split`` function which is now available for each DataTable


## Example
``Split`` function returns a collection of Split objects and can be used in a ``For Each`` activity:
![](https://raw.githubusercontent.com/dtila/uipath_datatable_extensions/main/docs/split/foreach.png)

Then change the ``ForEach`` activity type object from ``Object`` to ``SplitOperation`` like here:
![](https://raw.githubusercontent.com/dtila/uipath_datatable_extensions/main/docs/split/foreach-type.png)



## Feedback
The code is available at https://github.com/dtila/uipath_datatable_extensions and if you want to share your feedback/thoughts, please open a pull request at https://github.com/dtila/uipath_datatable_extensions/pulls

## Authors

**Daniel Tila** - is a systems engineer master degree in system architecture and 10+ years of experience. He worked on airplane engine software, train security doors to bank payment, and printing systems. 

He has more than 10 years of experience in the .NET programming environment. He designed applications that are facilitating communication between banks, printing services to airplane engines. How, he is a certified trainer in UiPath and co-founder at Automation Pill, a company that helps organizations optimize their costs by automating repetitive, mundane tasks. 

## Contributors ✨
This project is open source and we accept pull requests. If you want to be among contributors, [create a pull request](https://github.com/dtila/uipath_datatable_extensions/pulls). We are more than happy to include it in the code.

## Credits
Package icon: https://www.flaticon.com/free-icon/excel_3427627
