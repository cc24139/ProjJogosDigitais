# Assets Gratuitos — Jogo de Combate 2D (Side-Scroller / Fighter)

---

## 🎨 LuizMelo — Personagens Side-Scroller
**Página principal:** https://luizmelo.itch.io
**Licença:** CC0 — uso livre, inclusive comercial. Crédito não obrigatório.
**Estilo:** Pixel art fantasy medieval lateral. Todos têm as animações básicas para um fighter.

---

### Martial Hero
**Link:** https://luizmelo.itch.io/martial-hero
**Animações:** Idle (8f) · Run (8f) · Jump (4f) · Fall (4f) · Attack1 (6f) · Attack2 (6f) · Take Hit (4f) · Death (6f)

### Martial Hero 2
**Link:** https://luizmelo.itch.io/martial-hero-2
**Animações:** Idle (4f) · Run (8f) · Jump (2f) · Fall (2f) · Attack1 (4f) · Attack2 (4f) · Take Hit (3f) · Death (7f)

### Martial Hero 3
**Link:** https://luizmelo.itch.io/martial-hero-3
**Animações:** Idle (10f) · Run (8f) · Attack1 (7f) · Attack2 (6f) · Attack3 (9f) · Jump Up (3f) · Fall (3f) · Take Hit (3f) · Death (11f)

### Huntress
**Link:** https://luizmelo.itch.io/huntress
**Estilo:** Personagem feminina, arqueira/guerreira

### Huntress 2
**Link:** https://luizmelo.itch.io/huntress-2
**Estilo:** Versão alternativa da Huntress

### Evil Wizard
**Link:** https://luizmelo.itch.io/evil-wizard
**Estilo:** Mago vilão animado — ótimo para personagem de magia/projéteis

### Evil Wizard 2
**Link:** https://luizmelo.itch.io/evil-wizard-2
**Estilo:** Versão alternativa do Evil Wizard

### Fantasy Warrior
**Link:** https://luizmelo.itch.io/fantasy-warrior
**Estilo:** Guerreiro fantasy lateral

### Medieval Warrior Pack
**Link:** https://luizmelo.itch.io/medieval-warrior-pack
**Obs:** Pack com variações de guerreiro medieval

### Medieval Warrior Pack 2
**Link:** https://luizmelo.itch.io/medieval-warrior-pack-2
**Obs:** Segunda versão do pack com variações

### Medieval King Pack
**Link:** https://luizmelo.itch.io/medieval-king-pack
**Estilo:** Rei/Boss — ótimo como personagem final ou boss secreto

### Medieval King Pack 2
**Link:** https://luizmelo.itch.io/medieval-king-pack-2
**Obs:** Segunda versão do pack do rei

### Monsters Creatures Fantasy
**Link:** https://luizmelo.itch.io/monsters-creatures-fantasy
**Estilo:** Pack de criaturas/inimigos fantasy — útil para personagens não-humanos do roster

---

## ⚔️ Mattz Art — Samurai e Knight
**Licença:** Uso livre em projetos pessoais e comerciais. Não redistribuir como asset. Crédito apreciado.
**Estilo:** Pixel art lateral — visualmente consistente entre os dois personagens.

---

### Samurai 2D Pixel Art
**Link:** https://xzany.itch.io/samurai-2d-pixel-art
**Animações (versão gratuita):** Walk · Run · Hurt · Attack 1
**Obs:** A versão paga ($3) tem mais animações. A gratuita já serve para protótipo.

### FREE Knight 2D Pixel Art
**Link:** https://xzany.itch.io/free-knight-2d-pixel-art
**Animações:** Idle (3f) · Walk (8f) · Run (8f) · Jump (3f) · Defend (6f) · Hurt (3f) · Death (12f)
**Obs:** 100% gratuito. Sprite 32x32px.

---

## 🏰 Tiny Swords — Tileset de Cenários (Arenas)
**Link:** https://pixelfrog-assets.itch.io/tiny-swords
**Autor:** Pixel Frog
**Preço:** Gratuito (pay what you want)
**Licença:** Free Pack inclui tudo marcado com faixa azul. Uso livre.

### O que vem no pack gratuito:
- Todas as unidades humanas animadas
- Construções e estruturas medievais
- Recursos e decorações
- Tilesets de terreno (grama, pedra, castelo, água)
- Elementos de UI
- Variações de cor para fações diferentes (útil para diferenciar os lados na arena)

### Pack pago (Enemy Pack — $15):
- 16 inimigos especiais: Warrior, Lancer, Archer, Monk e mais
- 8 tipos de construções adicionais
- Conteúdo novo adicionado semanalmente

### Observação para uso lateral (side-scroller):
Os tilesets de chão, parede de castelo e decorações funcionam bem como
cenário de arena lateral — mesmo que o estilo original seja top-down/estratégia,
os elementos visuais são compatíveis com jogos de plataforma 2D.

---

## 📝 Dicas de uso na Unity

1. **Consistência visual:** use os personagens do LuizMelo como base do roster
   principal — todos têm o mesmo estilo, tamanho e qualidade de pixel art.

2. **Samurai e Knight (Mattz Art)** têm um estilo ligeiramente diferente do
   LuizMelo — considere usá-los como personagens "especiais" ou extras, ou
   ajustar a paleta de cores para aproximar os estilos.

3. **Sprite size:** LuizMelo geralmente usa sprites entre 48x48 e 96x96px.
   Verifique o tamanho exato de cada pack ao importar no Unity e padronize
   o PPU (Pixels Per Unit) para todos ficarem na mesma escala.

4. **Flip horizontal:** como todos são laterais, use SpriteRenderer.flipX = true
   na Unity para inverter a direção do personagem sem precisar de sprites extras.

5. **Tiny Swords na Unity:** o autor disponibilizou uma versão Unity do pack
   (Unity Package). Verifique na página do asset se ainda está disponível para
   download.