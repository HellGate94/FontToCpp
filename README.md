Complementary Code:

fonts.h
```cpp
    typedef struct _tCharInfo
    {
        unsigned int MemOffset;
        uint16_t Width;
        uint16_t Height;
        uint8_t OffsetX;
        uint8_t OffsetY;
    } sCharInfo;

    typedef struct _tFont
    {
        const uint8_t *table;
        const sCharInfo *infos;
    } sFONT;

    extern sFONT MyFont;
```

epdpaint.cpp
```cpp
int Paint::DrawCharAt(int x, int y, char ascii_char, sFONT *font, int colored)
{
    const sCharInfo ci = GetCharInfo(ascii_char, font);
    const int bytes_per_row = (ci.Width + 7) / 8;
    const unsigned int char_offset = ci.MemOffset;

    x += ci.OffsetX;
    y += ci.OffsetY;

    for (int j = 0; j < ci.Height; ++j)
    {
        for (int i = 0; i < ci.Width; ++i)
        {
            const unsigned char current_byte = font->table[char_offset + j * bytes_per_row + i / 8];
            const int bit_position = 7 - (i % 8);

            if (current_byte & (1 << bit_position))
            {
                DrawPixel(x + i, y + j, colored);
            }
        }
    }
    return ci.Width;
}

/**
 *  @brief: this displays a string on the frame buffer but not refresh
 */
void Paint::DrawStringAt(int x, int y, const char *text, sFONT *font, int colored, int letterspacing)
{
    const char *p_text = text;
    unsigned int counter = 0;
    int refcolumn = x;

    /* Send the string character by character on EPD */
    while (*p_text != 0)
    {
        char nextChar = *(p_text + 1);
        /* Display one character on EPD */
        int w = DrawCharAt(refcolumn, y, *p_text, font, colored);
        /* Decrement the column position by 16 */
        refcolumn += w + letterspacing;
        /* Point on the next character */
        p_text++;
        counter++;
    }
}

sCharInfo Paint::GetCharInfo(char ascii_char, sFONT *font)
{
    const int index = ascii_char - ' ';
    return font->infos[index];
}
```
