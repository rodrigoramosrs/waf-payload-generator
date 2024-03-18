# WAF Payload Generator

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://[github.com/rodrigoramosrs/waf-payload-generato](https://github.com/rodrigoramosrs/waf-payload-generator)r/blob/main/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/rodrigoramosrs/waf-payload-generator.svg)](https://github.com/rodrigoramosrs/waf-payload-generator/stargazers)
[![GitHub issues](https://img.shields.io/github/issues/rodrigoramosrs/waf-payload-generator.svg)](https://github.com/rodrigoramosrs/waf-payload-generator/issues)

A simple payload generator to bypass Web Application Firewalls (WAF) by converting text payloads to various encodings.


## Introduction

The WAF Payload Generator is a lightweight tool designed to help security researchers, penetration testers, and developers generate payloads to bypass Web Application Firewalls. It converts input payloads into various encodings, making it harder for WAFs to detect and block malicious inputs.

---

## Features

- Supports conversion 'N' to 'N' text encodings.
- Simple command-line interface for easy usage.
- Lightweight and fast operation.

---

## Usage

To use the WAF Payload Generator, simply run the script and provide the input payload as a command-line argument. The script will then generate payloads in various encodings.

```bash
$ dotnet run "payload_to_encode"
```

## License
This project is licensed under the MIT License.
