# P2P Auction System

## Overview
This project is a simple Peer-to-Peer (P2P) auction system implemented in C#. It simulates a basic auction process where clients can start auctions, place bids, and finalize auctions. Designed to operate through a console application, it facilitates interaction between clients and the auction server.

## Features
- **Start Auction:** Clients can initiate auctions for items with a starting bid.
- **Place Bid:** Clients can place bids on active auctions.
- **Finalize Auction:** The auction initiator can finalize the auction, determining the winning bid.

## How to Run
1. **Start the Auction Server:** Run the auction server application to begin listening for client requests.
2. **Client Operations:**
   - Start the client application.
   - Use command-line inputs to interact with the auction server (start auction, place bid, etc.).

## Note
- This project is a prototype and does not include database integration for persistent storage.
- Network configurations and error handling are simplified for demonstration purposes.

## Requirements
- .NET 5 or higher
- Compatible with Windows, Linux, and macOS
