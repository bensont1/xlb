﻿
using System;
using static Kitchen.ItemGroupView;

namespace KitchenXLB
{
    internal static class Helpers
    {
        private const string ModName = "XLB";

        // GDO
        public static T GetGDO<T>(int id) where T : GameDataObject
        {
            return GetExistingGDO(id) as T;
        }

        internal interface IWontRegister { }


        // Views
        public abstract class AccessedItemGroupView : ItemGroupView
        {
            protected abstract List<ComponentGroup> groups { get; }
            protected virtual List<ColourBlindLabel> labels => new();

            public virtual void Setup(Item gdo)
            {
                ComponentGroups = groups;
            }
        }


        // Materials
        public static void ApplyMaterial<T>(this GameObject gameObject, Material[] materials) where T : Renderer
        {
            var comp = gameObject.GetComponent<T>();
            if (comp == null)
                return;

            comp.materials = materials;
        }
        public static void ApplyMaterial(this GameObject gameObject, Material[] materials)
        {
            ApplyMaterial<MeshRenderer>(gameObject, materials);
        }
        public static void ApplyMaterialCafe(this GameObject gameObject, params string[] materials)
        {
            ApplyMaterial<MeshRenderer>(gameObject, GetMaterialArray(materials));
        }

        public static void ApplyMaterialToChildren<T>(this GameObject gameObject, string nameMatch, Material[] materials) where T : Renderer
        {
            for (int i = 0; i < gameObject.GetChildCount(); i++)
            {
                GameObject child = gameObject.GetChild(i);
                if (!child.name.ToLower().Contains(nameMatch.ToLower()))
                    continue;
                child.ApplyMaterial<T>(materials);
            }
        }
        public static void ApplyMaterialToChildren(this GameObject gameObject, string nameMatch, Material[] materials)
        {
            ApplyMaterialToChildren<MeshRenderer>(gameObject, nameMatch, materials);
        }
        public static void ApplyMaterialToChildren(this GameObject gameObject, string nameMatch, params string[] materials)
        {
            ApplyMaterialToChildren<MeshRenderer>(gameObject, nameMatch, GetMaterialArray(materials));
        }

        public static void ApplyMaterialToChild<T>(this GameObject gameObject, string childName, Material[] materials) where T : Renderer
        {
            gameObject.GetChild(childName).ApplyMaterial<T>(materials);
        }
        public static void ApplyMaterialToChildCafe(this GameObject gameObject, string childName, Material[] materials)
        {
            gameObject.GetChild(childName).ApplyMaterial(materials);
        }
        public static void ApplyMaterialToChildCafe(this GameObject gameObject, string childName, params string[] materials)
        {
            Debug.Log($"[MY MOD] game object " + gameObject.GetChild(childName));
            Debug.Log($"[MY MOD] " + GetMaterialArray(materials));
         
            gameObject.GetChild(childName).ApplyMaterial(GetMaterialArray(materials));
        }

        public static Material[] GetMaterialArray(params string[] materials)
        {
            List<Material> materialList = new List<Material>();
            foreach (string matName in materials)
            {
                string formatted = $"{ModName} - \"{matName}\"";
                string formatted2 = $"IngredientLib - \"{matName}\"";
                if (CustomMaterials.CustomMaterialsIndex.ContainsKey(formatted))
                {
                    materialList.Add(CustomMaterials.CustomMaterialsIndex[formatted]);
                }
                else if (CustomMaterials.CustomMaterialsIndex.ContainsKey(formatted2))
                {
                    materialList.Add(CustomMaterials.CustomMaterialsIndex[formatted2]);
                }
                else
                {
                    materialList.Add(MaterialUtils.GetExistingMaterial(matName));
                }
            }
            return materialList.ToArray();
        }

        // Material Generation
        public static Material CreateFlat(string name, Color color, float shininess = 0, float overlayScale = 10)
        {
            Material mat = new Material(Shader.Find("Simple Flat"));
            mat.name = $"{ModName} - \"{name}\"";
            mat.SetColor("_Color0", color);
            mat.SetFloat("_Shininess", shininess);
            mat.SetFloat("_OverlayScale", overlayScale);
            return mat;
        }
        public static Material CreateFlat(string name, int color, float shininess = 0, float overlayScale = 10)
        {
            return CreateFlat(name, ColorFromHex(color), shininess, overlayScale);
        }

        public static Material CreateTransparent(string name, Color color)
        {
            Material mat = new Material(Shader.Find("Simple Transparent"));
            mat.name = $"{ModName} - \"{name}\"";
            mat.SetColor("_Color", color);
            return mat;
        }
        public static Material CreateTransparent(string name, int color, float opacity)
        {
            Color col = ColorFromHex(color);
            col.a = opacity;
            return CreateTransparent(name, col);
        }

        // Color Utility
        public static Color ColorFromHex(int hex)
        {
            return new Color(((hex & 0xFF0000) >> 16) / 255.0f, ((hex & 0xFF00) >> 8) / 255.0f, (hex & 0xFF) / 255.0f);
        }
    }
}