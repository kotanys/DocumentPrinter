﻿namespace DocumentPrinter.Models
{
    public readonly struct DocumentData
    {
        public string OwnerName { get; init; }
        public string DocumentName { get; init; }
        public string FileName { get; init; }
    }
}