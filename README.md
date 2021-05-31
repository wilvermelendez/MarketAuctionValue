# MarketAuctionValue
Market + Auction Value

In this challenge, we have a JSON database and we have to understand its data structure and load its data into C# classes, and then create some basic methods to find and calculate Market Value and Auction Value.

MarketValue = {cost} x {marketRatio}
AuctionValue = {cost} x {auctionRatio}

For the solution we have to keep it simple and use a basic structure following SOLID patterns and XUnit for testing.

We have create one service to load data from the JSON Database and another service to calculate Market Value and Auction Value if the data is found in the DB.

Following we can see the JSON structure.
```json
{
    "67352": {
        "schedule": {
            "years": {
                "2006": {
                    "marketRatio": 0.311276,
                    "auctionRatio": 0.181383
                },
                "2007": {
                    "marketRatio": 0.317628,
                    "auctionRatio": 0.185085
                },
                "2008": {
                    "marketRatio": 0.324111,
                    "auctionRatio": 0.188862
                },
                "2009": {
                    "marketRatio": 0.330725,
                    "auctionRatio": 0.192716
                },
                "2010": {
                    "marketRatio": 0.363179,
                    "auctionRatio": 0.198498
                },
                "2011": {
                    "marketRatio": 0.374074,
                    "auctionRatio": 0.206337
                },
                "2012": {
                    "marketRatio": 0.431321,
                    "auctionRatio": 0.213178
                }
            },
            "defaultMarketRatio": 0.02,
            "defaultAuctionRatio": 0.02
        },
        "saleDetails": {
            "cost": 681252,
            "retailSaleCount": 122,
            "auctionSaleCount": 17
        },
        "classification": {
            "category": "Earthmoving Equipment",
            "subcategory": "Dozers",
            "make": "Caterpillar",
            "model": "D8T"
        }
    },
    "87390": {
        "schedule": {
            "years": {
                "2016": {
                    "marketRatio": 0.613292,
                    "auctionRatio": 0.417468
                },
                "2017": {
                    "marketRatio": 0.692965,
                    "auctionRatio": 0.473205
                },
                "2018": {
                    "marketRatio": 0.980485,
                    "auctionRatio": 0.684991
                },
                "2019": {
                    "marketRatio": 1.041526,
                    "auctionRatio": 0.727636
                },
                "2020": {
                    "marketRatio": 1.106366,
                    "auctionRatio": 0.772935
                }
            },
            "defaultMarketRatio": 0.06,
            "defaultAuctionRatio": 0.06
        },
        "saleDetails": {
            "cost": 48929,
            "retailSaleCount": 12,
            "auctionSaleCount": 127
        },
        "classification": {
            "category": "Aerial Equipment",
            "subcategory": "Boom Lifts",
            "make": "JLG",
            "model": "340AJ"
        }
    }
}
```
## Solution
For this solution we are using .Net Core as main technology and I have added docker file and Microsoft Identity Platform in order to be ready to implement Authenticantion and easy deploy using containers.


### Tech
- C# 
- Net Core 5 Web API
- Text JSON
- XUnit
- Docker
- Azure

## How to run this app
1. You can simple open the solution using Visual Studio  2019 with Net Core 5 and excecute it using Docker or IISExpress
1. You can build docker image using the docker file.
