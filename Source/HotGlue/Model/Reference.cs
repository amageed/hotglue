﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PT = System.IO.Path;

namespace HotGlue.Model
{
    public class Reference
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public bool Module { get; set; }

        public string GetPath()
        {
            return PT.Combine(Path, Name);
        }

        public string FullPath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) || !string.IsNullOrWhiteSpace(Path))
            {
                return PT.Combine(PT.Combine(PT.GetFullPath(path), Path.StartsWith("/") ? Path.Substring(1) : Path), Name.StartsWith("/") ? Name.Substring(1) : Name);
            }
            return Name;
        }

        public override bool Equals(object obj)
        {
            var reference = obj as Reference;
            if (reference == null) return false;

            return String.Compare(Name, reference.Name) == 0 &&
                   String.Compare(Path, reference.Path) == 0;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 11;
                hash = hash * 7 + Name.GetHashCode();
                hash = hash * 7 + Path.GetHashCode();
                return hash;
            }
        }
    }
}
