// ======================================================================================
// File         : exBitmapFont.cs
// Author       : Wu Jie 
// Last Change  : 07/15/2011 | 13:52:28 PM | Friday,July
// Description  : 
// ======================================================================================

///////////////////////////////////////////////////////////////////////////////
// usings
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///////////////////////////////////////////////////////////////////////////////
/// 
/// The bitmap font asset used in exSpriteFont component. 
/// 
///////////////////////////////////////////////////////////////////////////////

public class exBitmapFont : ScriptableObject {

    ///////////////////////////////////////////////////////////////////////////////
    ///
    /// A structure to descrip the character in the bitmap font 
    ///
    ///////////////////////////////////////////////////////////////////////////////

    [System.Serializable]
    public class CharInfo {
        public int id = -1;                ///< the character id 
        public int x = -1;                 ///< the x pos
        public int y = -1;                 ///< the y pos
        public int width = -1;             ///< the width
        public int height = -1;            ///< the height                          
        public int xoffset = -1;           ///< the xoffset
        public int yoffset = -1;           ///< the yoffset
        public int xadvance = -1;          ///< the xadvance
        public int page = -1;              ///< the number of pages used
        public Vector2 uv0 = Vector2.zero; ///< the uv
    }

    ///////////////////////////////////////////////////////////////////////////////
    ///
    /// A structure to descrip the kerning between two character in the bitmap font 
    ///
    ///////////////////////////////////////////////////////////////////////////////

    [System.Serializable]
    public class KerningInfo {
        public int first = -1;  ///< the id of first character 
        public int second = -1; ///< the id of second character
        public int amount = -1; ///< the amount of kerning
    }

    ///////////////////////////////////////////////////////////////////////////////
    ///
    /// A structure to descrip the page used in the bitmap font
    ///
    ///////////////////////////////////////////////////////////////////////////////

    [System.Serializable]
    public class PageInfo {
        public Texture2D texture; ///< the texture
        public Material material; ///< the default material
    }

    ///////////////////////////////////////////////////////////////////////////////
    // properties
    ///////////////////////////////////////////////////////////////////////////////

    public int lineHeight; ///< the space of the line
    public int size;       ///< the size in pixel of the font 

    public List<PageInfo> pageInfos = new List<PageInfo>(); ///< the list of the page information
    public List<CharInfo> charInfos = new List<CharInfo>(); ///< the list of the character information
    public List<KerningInfo> kernings = new List<KerningInfo>(); ///< the list of the kerning information 
    // public List<string> fontInfoGUIDs = new List<string>(); // TODO

    public bool inAtlas = false; ///< if the font saved in atlas
    public bool editorNeedRebuild = false; ///< if rebuild the font

    protected Dictionary<int,CharInfo> idToCharInfo = null;

    ///////////////////////////////////////////////////////////////////////////////
    // static
    ///////////////////////////////////////////////////////////////////////////////

    // ------------------------------------------------------------------ 
    /// Rebuild the table to store key exBitmapFont.CharInfo.id to value exBitmapFont.CharInfo
    // ------------------------------------------------------------------ 

    public void RebuildIdToCharInfoTable () {
        if ( idToCharInfo == null ) {
            idToCharInfo = new Dictionary<int,CharInfo>();
        }
        idToCharInfo.Clear();
        foreach ( CharInfo c in charInfos ) {
            idToCharInfo[c.id] = c;
        }
    }

    // ------------------------------------------------------------------ 
    /// \param _id the look up key 
    /// \return the expect character info
    /// Get the character information by exBitmapFont.CharInfo.id
    // ------------------------------------------------------------------ 

    public CharInfo GetCharInfo ( int _id ) {
        // create and build idToCharInfo table if null
        if ( idToCharInfo == null ) {
            idToCharInfo = new Dictionary<int,CharInfo>();
            foreach ( CharInfo c in charInfos ) {
                idToCharInfo[c.id] = c;
            }
        }

        //
        if ( idToCharInfo.ContainsKey (_id) )
            return idToCharInfo[_id];
        return null;
    }
}

